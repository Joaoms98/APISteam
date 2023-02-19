using APISteam.Domain.Entities;
using APISteam.Domain.Interface;
using APISteam.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace APISteam.Infra.Repositories
{
    public class CommentRepository : ICommentRepository
    {

        private readonly DataContext _context;

        public CommentRepository(DataContext context)
        {
             _context = context;
        }
        
        public IEnumerable<Comment> ListByGameId(Guid gameId)
        {
            IEnumerable<Comment> comments = _context.Comment
            .Where(c => c.GameId == gameId)
            .Include(c => c.User)
            .Select(c => new Comment{
                Description = c.Description,
                Review = c.Review,
                CreatedAt = c.CreatedAt,
                User = new User{
                    NickName = c.User.NickName,
                    Photo = c.User.Photo
                }
            })
            .ToList();

            return comments;
        }
    }
}