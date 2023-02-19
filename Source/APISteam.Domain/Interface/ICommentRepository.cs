using APISteam.Domain.Entities;

namespace APISteam.Domain.Interface
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> ListByGameId(Guid gameId);
    }
}