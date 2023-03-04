namespace APISteam.Domain.Interface
{
    public interface ILibraryRepository
    {
        void Create(Guid userId, double gameHours);
        void Update(Guid id, double gameHours);       
    }
}