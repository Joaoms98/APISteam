namespace APISteam.Domain.Interface
{
    public interface IDeveloperRepository
    {
        void Create(Guid userId, string document, string account);
        void Update(Guid id, string document, string account);

    }
}