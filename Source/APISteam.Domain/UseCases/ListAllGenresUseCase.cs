using APISteam.Core.Interfaces;
using APISteam.Domain.Interface;
using APISteam.Domain.Responses;
using AutoMapper;

namespace APISteam.Domain.UseCases
{
    public class ListAllGenresUseCase : IUseCase<IEnumerable<GenreListAllResponse>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ListAllGenresUseCase(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenreListAllResponse>> Execute()
        {
            var genre  = _uow.GenreRepository.ListAll();
            return await Task.FromResult(_mapper.Map<IEnumerable<GenreListAllResponse>>(genre));
        }
    }
}