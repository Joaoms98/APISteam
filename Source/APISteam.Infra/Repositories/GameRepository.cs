using APISteam.Domain.Entities;
using APISteam.Domain.Interface;
using APISteam.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace APISteam.Infra.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly DataContext _context;

        public GameRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Game> FindByIdWithAllRelationsAsync(Guid id)
        {
            Game game =  _context.Game
            .Where(x => x.Id == id)
            .Include(g => g.Video)
            .Include(g => g.Image)
            .Include(g => g.Comment)
            .Include(g => g.Developer)
            .Include(g => g.Publisher)
            .Include(g => g.GameGenre)
            .Include(g => g.SystemRequirement)
            .FirstOrDefault();

            return await Task.FromResult(game);
        }

        public async Task<IEnumerable<Game>> ListWithSmallerPriceAsync(double price)
        {
            IEnumerable<Game> games = _context.Game
                .Where(g => g.Price <= price)
                .Include(g => g.Comment.Where(c => c.Review == true))
                .Select(g => new Game{
                    Logo = g.Logo,
                    Price = g.Price, 
                    Comment = g.Comment
                })
                .OrderBy(g => g.Comment.Count())
                .Take(8);

            return await Task.FromResult(games);
        }
    }
}