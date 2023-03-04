using APISteam.Core.Exceptions;
using APISteam.Domain.Entities;
using APISteam.Domain.Interface;
using APISteam.Infra.Data;

namespace APISteam.Infra.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly DataContext _context;

        public VideoRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Guid gameId, string link)
        {
            Video video = new Video()
            {
                Id = Guid.NewGuid(),
                GameId = gameId,
                Link = link
            };
            _context.Add(video);
            _context.SaveChanges();
        }
        public void Update(Guid id, string link)
        {
            var video = _context.Video.Find(id);
            if(video is null)
            {
                throw new NotFoundException("Vídeo não encontrado");
            }
            
            video.Link = link;
            _context.Update(video);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var video = _context.Video.Find(id);

            if(video is null)
            {
                throw new NotFoundException("Vídeo não encontrado");
            }
            _context.Remove(video);
            _context.SaveChanges();
        }

        public IEnumerable<Video> ListAll(Guid gameId)
        {
            var video =  _context.Video
            .Where(v => v.GameId == gameId);
            
            return video;
        }
    }
}