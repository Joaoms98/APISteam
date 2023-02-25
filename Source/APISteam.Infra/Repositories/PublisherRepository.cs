using APISteam.Core.Exceptions;
using APISteam.Domain.Entities;
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

        public void Create(Guid userId, string name)
        {
            Publisher publisher = new Publisher()
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Name = name
            };

            _context.Add(publisher);
            _context.SaveChanges();
        }

        public void Update(Guid id, string name)
        {
            var publisher = _context.Publisher.Find(id);

            if (publisher is null)
            {
                throw new NotFoundException("Publicadora não localizada");
            }

            publisher.Name = name;

            _context.Update(publisher);
            _context.SaveChanges();
        }
    }
}