using APISteam.Domain.Inputs;
using APISteam.Domain.UseCases;
using APISteam.Web.Filters;
using APISteam.Web.FormRequest;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APISteam.Web.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    protected readonly IMapper _mapper;
    protected readonly ExceptionFilter _exceptionFilter;

    public UserController(IMapper mapper, ExceptionFilter exceptionFilter)
    {
        _mapper = mapper;
        _exceptionFilter = exceptionFilter;
    }

    [HttpPost("sign-in")]
    public async Task<ActionResult> Register([FromBody] RegisterUserFormRequest payload, [FromServices] RegisterUserUseCase useCase)
    {
        try
        {
            var input = new UserRegisterInput()
            {
                NickName = payload.NickName,
                Email = payload.Email,
                Password = payload.Password,
                Country = payload.Country
            };

            await useCase.Execute(input);
            return Created("Success", new{});
        }
        catch(Exception ex)
        {
            return await _exceptionFilter.MakeStatusCode(ex);
        }
    }
}
