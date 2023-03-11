using APISteam.Core.Interfaces;
using APISteam.Domain.Inputs;
using APISteam.Domain.Interface;
using AutoMapper;

namespace APISteam.Domain.UseCases
{
    public class UpdateUserUseCase : IUseCase<object, UserUpdateInput>
    {

        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UpdateUserUseCase(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<object> Execute(UserUpdateInput input)
        {
            _uow.UserRepository.GetById(input.Id);

            _uow.UserRepository.Update(
                input.Id,
                input.NickName,
                input.Password,
                input.RealName,
                input.Resume,
                input.Country,
                input.State,
                input.City,
                input.Photo
            );

            await _uow.CommitAsync();
            return new{};
        }

    }
}