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
    }
}