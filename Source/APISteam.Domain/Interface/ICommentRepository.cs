using APISteam.Domain.Entities;

namespace APISteam.Domain.Interface
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> ListByGameId(Guid gameId);

        void Create(Guid gameId, Guid userId, string description, bool review);

        void Update(Guid id, string description, bool review);

        void Delete(Guid id);
    }
}