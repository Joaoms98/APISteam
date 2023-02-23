using APISteam.Core.Exceptions;
using APISteam.Domain.Entities;
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

        public void Create(Guid gameId, int minMax, string processor, string memory, string graphics, string directx, string storage, string addionalInfo)
        {
            SystemRequirement  systemRequirement = new SystemRequirement()
            {
                Id = Guid.NewGuid(),
                GameId = gameId,
                MinMax = minMax,
                Processor = processor,
                Memory = memory,
                Graphics = graphics,
                DirectX = directx,
                Storage = storage,
                AdditionalInfo = addionalInfo
            };

            _context.Add(systemRequirement);
            _context.SaveChanges();

        }

        public void Update(Guid id, int minMax, string processor, string memory, string graphics, string directx, string storage, string addionalInfo)
        {
            SystemRequirement systemRequirement = _context.SystemRequirement.Find(id);

            if (systemRequirement is null)
            {
                throw new NotFoundException("Requisitos de sistema não localizado");
            }

            systemRequirement.MinMax = minMax;
            systemRequirement.Processor = processor;
            systemRequirement.Memory = memory;
            systemRequirement.Graphics = graphics;
            systemRequirement.DirectX = directx;
            systemRequirement.Storage = storage;
            systemRequirement.AdditionalInfo = addionalInfo;

            _context.Update(systemRequirement);
            _context.SaveChanges();

        }

        public void Delete(Guid id)
        {
            var systemRequirement = _context.SystemRequirement.Find(id);
            if (systemRequirement is null)
            {
                throw new NotFoundException("Requisitos de sistema não localizado");
            }

            _context.Remove(systemRequirement);
            _context.SaveChanges();
        }


    }
}