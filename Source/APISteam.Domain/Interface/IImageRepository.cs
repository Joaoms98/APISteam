using APISteam.Domain.Entities;

namespace APISteam.Domain.Interface
{
    public interface IImageRepository
    {
        IEnumerable<Image> ListAll();
        void Create(Guid gameId, string link);
        void Update(Guid id, string link);
        void Delete(Guid id);
    }
}