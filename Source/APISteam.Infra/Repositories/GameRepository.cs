using APISteam.Domain.Entities;
using APISteam.Domain.Interface;
using APISteam.Infra.Data;
using APISteam.Infra.Services;
using Microsoft.EntityFrameworkCore;

namespace APISteam.Infra.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly DataContext _context;
        private readonly FeaturedAndRecommendsFilter _filter;

        public GameRepository(DataContext context, FeaturedAndRecommendsFilter filter)
        {
            _context = context;
            _filter = filter;
        }

        // public Game FindByIdWithAllRelationsAsync(Guid id)
        // {
        //     Game game =  _context.Game
        //     .Where(x => x.Id == id)
        //     .Include(g => g.Video)
        //     .Include(g => g.Image)
        //     .Include(g => g.Comment)
        //     .Include(g => g.Developer)
        //     .Include(g => g.Publisher)
        //     .Include(g => g.GameGenre)
        //     .Include(g => g.SystemRequirement)
        //     .FirstOrDefault();

        //     return game;
        // }

        public IEnumerable<Game> ListWithSmallerPriceAsync(double price)
        {
            IEnumerable<Game> games = _context.Game
                .Where(g => g.Price <= price)
                .Include(g => g.Comment.Where(c => c.Review == true))
                .Select(g => new Game{
                    Id = g.Id,
                    Logo = g.Logo,
                    Price = g.Price, 
                    Comment = g.Comment
                })
                .OrderByDescending(g => g.Comment.Count())
                .Take(8);

            return games;
        }

        public IEnumerable<Game> ListByRelevance(Guid? userId)
        {
            if(userId == null || userId == Guid.Empty)
            {
                return _filter.RelevanceFilter();
            }

            return _filter.RelevanceFilterByUserLibrary(userId);
        }
    }
}