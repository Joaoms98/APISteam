namespace APISteam.Domain.Interface
{
    public interface IFranchiseRepository
    {
        void Create(string name);
        void Update(Guid id,string name);
        void Delete(Guid id);
    }
}