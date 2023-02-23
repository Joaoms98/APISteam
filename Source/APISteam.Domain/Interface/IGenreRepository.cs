using APISteam.Domain.Entities;

namespace APISteam.Domain.Interface
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> ListAll();

        void Create(int type);
        void Update(Guid id, int type);
        void Delete(Guid id);
    }
}