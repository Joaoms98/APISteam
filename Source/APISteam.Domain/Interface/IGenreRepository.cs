using APISteam.Domain.Entities;

namespace APISteam.Domain.Interface
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> ListAllAsync();
    }
}