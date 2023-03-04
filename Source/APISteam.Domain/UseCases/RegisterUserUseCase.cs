using System.ComponentModel.DataAnnotations;
using APISteam.Core.Interfaces;
using APISteam.Domain.Inputs;
using APISteam.Domain.Interface;
using AutoMapper;

namespace APISteam.Domain.UseCases
{
    public class RegisterUserUseCase : IUseCase<object, UserRegisterInput>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public RegisterUserUseCase(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<object> Execute(UserRegisterInput input)
        {

            UserEmailAlreadyExists(input.Email);

            _uow.UserRepository.Create(
                input.NickName,
                input.Email,
                input.Password,
                input.Country
            );

            await _uow.CommitAsync();
            return new{};
        }

        private void UserEmailAlreadyExists(string email)
        {
           bool validate =  _uow.UserRepository.UserEmailAlreadyExists(email);

           if(validate is true)
           {
                throw new ValidationException();
           }
        }
    }
}