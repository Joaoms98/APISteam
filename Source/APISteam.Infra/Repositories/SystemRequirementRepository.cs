using APISteam.Domain.Interface;
using APISteam.Infra.Data;

namespace APISteam.Infra.Repositories
{
    public class SystemRequirementRepository : ISystemRequirementRepository
    {
        private readonly DataContext _context;

        public SystemRequirementRepository(DataContext context)
        {
            _context = context;
        }
    }
}