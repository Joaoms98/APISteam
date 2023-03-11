using APISteam.Core.Exceptions;
using APISteam.Core.Interfaces;
using APISteam.Domain.Entities;
using APISteam.Domain.Inputs;
using APISteam.Domain.Interface;

namespace APISteam.Domain.UseCases
{
    public class DeleteUserUseCase : IUseCase<object, UserDeleteInput>
    {

        private readonly IUnitOfWork _uow;
        private Dictionary<string, string> errors = new Dictionary<string, string>();
        public DeleteUserUseCase(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<object> Execute(UserDeleteInput input)
        {
            User userValidation = _uow.UserRepository.GetById(input.Id);

            if (userValidation.NickName != input.NickName)
            {
                errors.Add("NickName","O conteúdo escrito deve ser idêntico ao NickName");
            }

            ValidateErrors();
            _uow.UserRepository.Delete(input.Id);

            await _uow.CommitAsync();
            return new { };
        }

        private void ValidateErrors()
        {
            if(errors.Count() > 0)
            {
                throw new ValidationException("Validations",errors);
            }
        }
    }
}