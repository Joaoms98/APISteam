using APISteam.Domain.Entities;

namespace APISteam.Domain.Interface
{
    public interface IUserRepository
    {
        void Create(string email, string password, string nickName, string country);
        
        void Update(Guid id, string nickName, string password, string realName, 
            string resume,string country,string state, string city, string photo);
        
        void Delete(Guid id);
        User GetById(Guid id);
        IEnumerable<User> ListAll();
        IEnumerable<User> ListByNickName(string nickName);
    }
}