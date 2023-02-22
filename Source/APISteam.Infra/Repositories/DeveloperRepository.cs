using APISteam.Core.Exceptions;
using APISteam.Domain.Entities;
using APISteam.Domain.Interface;
using APISteam.Infra.Data;

namespace APISteam.Infra.Repositories
{
    public class DeveloperRepository : IDeveloperRepository
    {

        private readonly DataContext _context;
        
        public DeveloperRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Guid userId, string document, string account)
        {
            var developer = new Developer()
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Document = document,
                Account = account
            };

            _context.Add(developer);
            _context.SaveChanges();

        }

        public void Update(Guid id, string document, string account)
        {
            var developer = _context.Developer.Find(id);

            if(developer is null)
            {
                throw new NotFoundException("Desenvolvedor não encontrado");
            }

            developer.Document = document;
            developer.Account = account;

            _context.Update(developer);
            _context.SaveChanges();

        }
    }
}