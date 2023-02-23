namespace APISteam.Domain.Interface
{
    public interface IImageRepository
    {
        void Create(Guid gameId, string link);
        void Update(Guid id, string link);
        void Delete(Guid id);
    }
}