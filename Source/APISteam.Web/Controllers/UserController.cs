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

    [HttpPut("update/{id}")]
    public async Task<ActionResult> Update(
        [FromRoute]Guid id,
        [FromBody] UpdateUserFormRequest payload,
        [FromServices] UpdateUserUseCase useCase
    )
    {
        try
        {
            var input = new UserUpdateInput()
            {
                Id = id,
                NickName = payload.NickName,
                Password = payload.Password,
                RealName = payload.RealName,
                Resume = payload.Resume,
                Country = payload.Country,
                State = payload.State,
                City = payload.City,
                Photo = payload.Photo
            };
            await useCase.Execute(input);
            return NoContent();
        }
        catch(Exception ex)
        {
            return await _exceptionFilter.MakeStatusCode(ex);
        }
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> Delete(
        [FromRoute] Guid id,
        [FromBody] DeleteUserFormRequest payload,
        [FromServices] DeleteUserUseCase useCase
    )

    {
        try
        {
            var input = new UserDeleteInput()
            {
                Id = id,
                NickName = payload.NickName
            };
            await useCase.Execute(input);
            return NoContent();
        }
        catch(Exception ex)
        {
            return await _exceptionFilter.MakeStatusCode(ex);
        }
    }

}
