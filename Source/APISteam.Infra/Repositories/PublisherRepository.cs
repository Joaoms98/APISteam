using APISteam.Domain.Interface;
using APISteam.Infra.Data;

namespace APISteam.Infra.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly DataContext _context;

        public PublisherRepository(DataContext context)
        {
            _context = context;
        }
    }
}