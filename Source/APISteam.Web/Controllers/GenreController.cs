using APISteam.Domain.UseCases.Genre;
using APISteam.Web.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APISteam.Web.Controllers;

[ApiController]
[Route("genre")]
public class GenreController : ControllerBase
{
    protected readonly IMapper _mapper;

    public GenreController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult> ListAll([FromServices] ListAllGenresUseCase useCase)
    {
        try
        {
            var result = await useCase.Execute();
            return Ok(_mapper.Map<IEnumerable<GenreListAllResource>>(result));
        }
        catch(Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
