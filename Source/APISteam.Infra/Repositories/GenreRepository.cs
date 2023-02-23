using APISteam.Core.Exceptions;
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

        public void Create(int type)
        {

            Genre genre = new Genre()
            {
             Id = Guid.NewGuid(),
             Type = type
            };

            _context.Add(genre);
            _context.SaveChanges();

        }

        public void Update(Guid id, int type)
        {
            Genre genre = _context.Genre.Find(id);
            if(genre is null)
            {
                throw new NotFoundException("Gênero não encontrado"); 
            };

            genre.Type = type;

            _context.Update(genre);
            _context.SaveChanges();

        }

        public void Delete(Guid id)
        {
            Genre genre = _context.Genre.Find(id);
            if(genre is null)
            {
                throw new NotFoundException("Gênero não encontrado"); 
            };

            _context.Remove(genre);
            _context.SaveChanges();
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