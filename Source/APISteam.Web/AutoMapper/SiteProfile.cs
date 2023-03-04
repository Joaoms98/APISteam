using APISteam.Domain.Responses;
using APISteam.Web.Resources;
using AutoMapper;

namespace APISteam.Web.AutoMapper;

public class SiteProfile : Profile
{
    public SiteProfile()
    {
        CreateMap<GenreListAllResponse, GenreListAllResource>();
    }
}
