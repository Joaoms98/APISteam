using APISteam.Core.Exceptions;
using APISteam.Core.Utils;
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

        public IEnumerable<Game> SearchByParams(string param)
        {
            var games = _context.Game
                .Where(x => x.Title.Contains(param) 
                    || x.PredominantGenre == param.EncodeToIntGenreEnum()
                )
                .ToList();

            return games;
        }


        public IEnumerable<Game> ListByGenre(Guid genreId)
        {
            var games = _context.GameGenre
            .Include(g => g.Game)
            .Include(g => g.Genre)
            .Where(g => g.Genre.Id == genreId)
            .Select(g => new Game
            {
                Logo = g.Game.Logo,
                Price = g.Game.Price
            })
            .ToList();
    
            return games;
        }

        public void Create(Guid developerId, Guid publisherId, Guid franchiseId, string title, double price, string description, int predominantGenre)
        {
            var game = new Game()
            {
                Id = Guid.NewGuid(),
                DeveloperId = developerId,
                PublisherId = publisherId,
                FranchiseId = franchiseId,
                Title = title,
                Price = price,
                Description = description,
                PredominantGenre = predominantGenre
            };

            _context.Add(game);
            _context.SaveChanges();
        }

        public void Update(Guid id, string title, double price, string description, int predominantGenre)
        {
            var game = _context.Game.Find(id);

            if(game is null)
            {
                throw new NotFoundException("Jogo não encontrado"); 
            }

            game.Title = title;
            game.Price = price;
            game.Description = description;
            game.PredominantGenre = predominantGenre;
            
            _context.Update(game);
            _context.SaveChanges();


        }

        public void Delete(Guid id)
        {
            var game = _context.Game.Find(id);

            if(game is null)
            {
                throw new NotFoundException("Jogo não encontrado"); 
            };

            _context.Remove(game);
            _context.SaveChanges();
        }

    }
}