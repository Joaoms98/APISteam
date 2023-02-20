using APISteam.Domain.Entities;
using APISteam.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace APISteam.Infra.Services;

public class FeaturedAndRecommendsFilter
{
    private readonly DataContext _context;

    public FeaturedAndRecommendsFilter(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<Game> RelevanceFilter()
    {
        var games = _context.Game
            .Include(g => g.Library)
            .Include(g => g.Image)
            .OrderByDescending(g => g.Library.Count())
            .Select(g => new Game{
                Id = g.Id,
                Logo = g.Logo,
                Title = g.Title,
                Price = g.Price,
                Image = g.Image.Take(4).ToList()
            })
            .Take(12)
            .ToList();
        
        return games;
    }

    public IEnumerable<Game> RelevanceFilterByUserLibrary(Guid? userId)
    {
        var gamesByUserId = _context.Library
            .Where(l => l.UserId == userId)
            .Select(l => new{
                Game = l.Game
            })
            .ToList();

        if(gamesByUserId.Count() == 0)
        {
            return RelevanceFilter();
        }

        List<int> genresTypes = new List<int>();

        foreach(var game in gamesByUserId)
        {
            genresTypes.Add(game.Game.PredominantGenre);
        }

        var genresOccurrences = genresTypes
                        .GroupBy(x => x)
                        .Where(g => g.Count() > 1)
                        .ToDictionary(x => x.Key, x => x.Count())
                        .OrderByDescending(x => x.Value)
                        .Take(3);

        if(genresOccurrences.Count() == 0)
        {
            return RelevanceFilter();
        }

        List<Game> gamesFilterByRelevanceAndGenres = new List<Game>();

        for(int i =0; i < genresOccurrences.Count();i++)
        {
            gamesFilterByRelevanceAndGenres.AddRange( _context.Game
                .Include(g => g.Library)
                .Where(g => g.PredominantGenre == genresOccurrences.ElementAt(i).Key)
                .OrderByDescending(g => g.Library.Count())
                .Select(g => new Game{
                    Id = g.Id,
                    Logo = g.Logo,
                    Title = g.Title,
                    Price = g.Price,
                    Image = g.Image.Take(4).ToList()
                })
                .Take(4)
                .ToList()
            );
        }

        var gamesByRelevance = RelevanceFilter();

        if(gamesFilterByRelevanceAndGenres.Count() < 12)
        {
            gamesFilterByRelevanceAndGenres.AddRange(gamesByRelevance.Take(gamesFilterByRelevanceAndGenres.Count() - 12));
        }

        return gamesFilterByRelevanceAndGenres;
    }
}
