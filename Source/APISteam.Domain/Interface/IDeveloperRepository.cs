using APISteam.Domain.Entities;

namespace APISteam.Domain.Interface
{
    public interface IDeveloperRepository
    {
        Developer GetById(Guid id);
        void Create(Guid userId, string document, string account);
        void Update(Guid id, string document, string account);

    }
}