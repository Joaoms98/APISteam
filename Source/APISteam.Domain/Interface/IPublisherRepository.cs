namespace APISteam.Domain.Interface
{
    public interface IPublisherRepository
    {
        void Create(Guid userId, string name);
        void Update(Guid id, string name);        
      
    }
}