using APISteam.Domain.Entities;

namespace APISteam.Domain.Interface
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> ListAllAsync();
    }
}