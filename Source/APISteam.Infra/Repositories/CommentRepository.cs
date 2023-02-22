using APISteam.Core.Exceptions;
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

        public void Create(Guid gameId, Guid userId, string description, bool review)
        {
           
            var comment = new Comment()
            {
                Id = Guid.NewGuid(),
                GameId = gameId,
                UserId = userId,
                Description = description,
                Review = review,
                CreatedAt = DateTime.UtcNow
            };
            
            _context.Add(comment);
            _context.SaveChanges();
            
        }
        public void Update(Guid id, string description, bool review)
        {
            var comment = _context.Comment.Find(id);
            if(comment is null)
            {
                throw new NotFoundException("Comentário não encontrado");
            }

            comment.Description = description;
            comment.Review = review;    

            _context.Update(comment);
            _context.SaveChanges();  
        }


        public void Delete(Guid id)
        {
            var comment = _context.Comment.Find(id);

             if(comment is null)
            {
                throw new NotFoundException("Comentário não encontrado");
            }
            _context.Remove(comment);
            _context.SaveChanges();
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