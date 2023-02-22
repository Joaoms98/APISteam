using APISteam.Domain.Entities;

namespace APISteam.Domain.Interface
{
    public interface IGameRepository
    {
        IEnumerable<Game> ListWithSmallerPriceAsync(double price);
        
        // Game FindByIdWithAllRelationsAsync(Guid id);
        IEnumerable<Game> SearchByParams(string param);
        IEnumerable<Game> ListByGenre(Guid genreid);
    }
}