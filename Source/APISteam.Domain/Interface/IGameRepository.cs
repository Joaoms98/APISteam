using APISteam.Domain.Entities;

namespace APISteam.Domain.Interface
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> ListWithSmallerPriceAsync(Decimal price);

        Task<Game> FindByIdWithAllRelationsAsync(Guid id);
    }
}