using APISteam.Domain.Entities;

namespace APISteam.Domain.Interface
{
    public interface IGameRepository
    {
        IEnumerable<Game> ListWithSmallerPriceAsync(double price);
        
        // Game FindByIdWithAllRelationsAsync(Guid id);
        IEnumerable<Game> ListByRelevance(Guid? userId);
        IEnumerable<Game> SearchByParams(string param);
        IEnumerable<Game> ListByGenre(Guid genreid);
        void Create(Guid developerId, Guid publisherId, Guid franchiseId,
            string title, double price, string description, int predominantGenre);
        void Update(Guid id, string title, double price, string description, int predominantGenre);
        void Delete(Guid id);
    }
}