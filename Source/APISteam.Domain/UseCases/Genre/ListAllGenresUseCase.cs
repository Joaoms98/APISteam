using APISteam.Core.Interfaces;
using APISteam.Domain.Interface;
using APISteam.Domain.Responses.Genre;
using AutoMapper;

namespace APISteam.Domain.UseCases.Genre
{
    public class ListAllGenresUseCase : IUseCase<IEnumerable<GenreListAllResponse>>
    {
        private readonly IGenreRepository _repository;
        private readonly IMapper _mapper;

        public ListAllGenresUseCase(IGenreRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenreListAllResponse>> Execute()
        {
            var genre  = _repository.ListAll();
            return await Task.FromResult(_mapper.Map<IEnumerable<GenreListAllResponse>>(genre));
        }
    }
}