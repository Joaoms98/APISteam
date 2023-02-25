using APISteam.Core.Exceptions;
using APISteam.Domain.Entities;
using APISteam.Domain.Interface;
using APISteam.Infra.Data;

namespace APISteam.Infra.Repositories
{
    public class FranchiseRepository : IFranchiseRepository
    {
        private readonly DataContext _context;
        
        public FranchiseRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(string name)
        {
            Guid id = Guid.NewGuid();
            Franchise franchise = new Franchise()
            {
                Id = id,
                Name = name
            };

            _context.Add(franchise);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var franchise = _context.Franchise.Find(id);

            if(franchise is null)
            {
                throw new NotFoundException("Franquia não encontrada");
            }

            _context.Remove(franchise);
            _context.SaveChanges();
        }

        public void Update(Guid id, string name)
        {
            var franchise = _context.Franchise.Find();
            if(franchise is null)
            {
                throw new NotFoundException("Franquia não encontrada");
            }
            
            franchise.Name = name;

            _context.Add(franchise);
            _context.SaveChanges();
        }
    }
}