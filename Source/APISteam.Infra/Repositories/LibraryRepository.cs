using APISteam.Core.Exceptions;
using APISteam.Domain.Entities;
using APISteam.Domain.Interface;
using APISteam.Infra.Data;

namespace APISteam.Infra.Repositories
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly DataContext _context;

        public LibraryRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Guid userId, double gameHours)
        {
           var library = new Library()
           {
                Id = Guid.NewGuid(),
                UserId = userId,
                GameHours = gameHours
           };

           _context.Add(library);
           _context.SaveChanges();
        }

        public void Update(Guid id, double gameHours)
        {
            var library = _context.Library.Find(id);
            if (library is null)
            {
                throw new NotFoundException("Biblioteca não localizada");
            }

            library.GameHours = gameHours;

           _context.Update(library);
           _context.SaveChanges();
        }
    }
}