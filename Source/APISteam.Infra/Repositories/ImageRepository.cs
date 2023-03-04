using APISteam.Core.Exceptions;
using APISteam.Domain.Entities;
using APISteam.Domain.Interface;
using APISteam.Infra.Data;

namespace APISteam.Infra.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly DataContext _context;

        public ImageRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Guid gameId, string link)
        {
            Image image = new Image()
            {
                Id = Guid.NewGuid(),
                GameId = gameId,
                Link = link
            };

        _context.Add(image);
        _context.SaveChanges();


        }

        public void Update(Guid id, string link)
        {
            var image = _context.Image.Find(id);

            if (image is null)
            {
                throw new NotFoundException("Imagem não localizada");
            }

            image.Link = link;

        _context.Update(image);
        _context.SaveChanges();

        }

        public void Delete(Guid id)
        {
           var image = _context.Image.Find(id);

            if (image is null)
            {
                throw new NotFoundException("Imagem não localizada");
            }

        _context.Remove(image);
        _context.SaveChanges();

        }

        public IEnumerable<Image> ListAll(Guid gameId)
        {
            var image =  _context.Image
            .Where(i => i.GameId == gameId);
            
            return image;
        }
    }
}