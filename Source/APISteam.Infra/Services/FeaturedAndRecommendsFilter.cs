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
        List<Library> libraryByUserId = _context.Library
            .Where(l => l.UserId == userId)
            .Select(l => new Library{
                GameId = l.GameId
            })
            .ToList();

        if(libraryByUserId.Count() == 0)
        {
            return RelevanceFilter();
        }
        
        List<int> genresTypes = new List<int>();

        foreach(var library in libraryByUserId)
        {
            List<Genre> gameGenres = _context.GameGenre
                .Include(gg => gg.Genre)
                .Where(gg => gg.GameId == library.GameId)
                .Select(gg => new Genre{
                    Type = gg.Genre.Type
                })
                .ToList();
            
            foreach(var genre in gameGenres)
            {
                genresTypes.Add(genre.Type);
            }
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
            gamesFilterByRelevanceAndGenres.AddRange( _context.GameGenre
                .Include(gg => gg.Genre)
                .Include(gg => gg.Game)
                .OrderByDescending(gg => gg.Game.Library.Count())
                .Where(gg => gg.Genre.Type == genresOccurrences.ElementAt(i).Key)
                .Select(gg => new Game{
                    Id = gg.Game.Id,
                    Logo = gg.Game.Logo,
                    Title = gg.Game.Title,
                    Price = gg.Game.Price,
                    Image = gg.Game.Image.Take(4).ToList()
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
