using APISteam.Domain.Entities;

namespace APISteam.Domain.Interface
{
    public interface IVideoRepository
    {
        IEnumerable<Video> ListAll();
        void Create(Guid gameId, string link);
        void Update(Guid id, string link);
        void Delete(Guid id);
    }
}