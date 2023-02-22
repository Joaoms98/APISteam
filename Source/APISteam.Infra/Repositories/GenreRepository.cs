using APISteam.Domain.Entities;
using APISteam.Domain.Interface;
using APISteam.Infra.Data;

namespace APISteam.Infra.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DataContext _context;

        public GenreRepository(DataContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Genre> ListAll()
        {
            IEnumerable<Genre> genres = _context.Genre
            .Select(g => new Genre{
                Image = g.Image,
                Type = g.Type
            })
            .ToList();

            return genres;
        }
    }
}