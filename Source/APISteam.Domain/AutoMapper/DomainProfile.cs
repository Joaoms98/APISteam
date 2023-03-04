using APISteam.Domain.Entities;
using APISteam.Domain.Responses;
using AutoMapper;

namespace APISteam.Domain.AutoMapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Genre, GenreListAllResponse>(MemberList.Destination);
        }
    }
}