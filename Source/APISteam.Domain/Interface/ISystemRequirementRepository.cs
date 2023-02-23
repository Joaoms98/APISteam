namespace APISteam.Domain.Interface
{
    public interface ISystemRequirementRepository
    {
        void Create(Guid gameId, int minMax, 
            string processor, string memory,
             string graphics, string directx,
              string storage, string addionalInfo);
        void Update(Guid id, int minMax,
            string processor, string memory,
             string graphics, string directx,
              string storage, string addionalInfo);
        void Delete(Guid id);
    }
}