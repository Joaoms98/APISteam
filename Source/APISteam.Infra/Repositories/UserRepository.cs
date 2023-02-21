using APISteam.Core.Exceptions;
using APISteam.Domain.Entities;
using APISteam.Domain.Interface;
using APISteam.Infra.Data;

namespace APISteam.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(string email, string password, string nickName, string country)
        {
            var id = Guid.NewGuid();
            var user = new User()
            {
                Id = id,
                NickName = nickName,
                Email = email,
                Password = password,
                Country = country
            };
            _context.Add(user);
            _context.SaveChanges();
        }

        public void Update(Guid id, string nickName, string password, string realName, string resume, string country, string state, string city, string photo)
        {
            var user = _context.User.Find(id);
            
            if(user is null)
            {
                throw new NotFoundException("Usuário não encontrado");
            }

            user.NickName = nickName;
            user.Password = password;
            user.RealName = realName;
            user.Resume = resume;
            user.Country = country;
            user.State = state;
            user.City = city;
            user.Photo = photo;
            
            _context.Update(user);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var user = _context.User.Find(id);

            if(user is null)
            {
                throw new NotFoundException("Usuário não encontrado");
            }

            _context.Remove(user);
            _context.SaveChanges();
        }

        public User GetById(Guid id)
        {
            var user = _context.User.Find(id);

            if(user is null)
            {
                throw new NotFoundException("Usuário não encontrado");
            }

            return user;
        }

        public IEnumerable<User> ListAll()
        {
            IEnumerable<User> users = _context.User.ToList();

            return users;
        }

        public IEnumerable<User> ListByNickName(string nickName)
        {
            IEnumerable<User> users = _context.User
            .Where(u => u.NickName.Contains(nickName))
            .ToList();

            return users;
        }
    }
}