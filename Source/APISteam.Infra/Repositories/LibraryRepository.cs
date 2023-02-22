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
    }
}