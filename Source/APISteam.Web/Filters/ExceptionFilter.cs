using APISteam.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace APISteam.Web.Filters;

public class ExceptionFilter : ControllerBase
{
    public async Task<ActionResult> MakeStatusCode(Exception ex)
    {
        if(ex !=null)
        {
            if(ex is DuplicateKeyException)
            {
                return UnprocessableEntity(ex.Message);
            }

            if(ex is ForbiddenException)
            {
                return Forbid(ex.Message);
            }

            if(ex is NotFoundException)
            {
                return NotFound(ex.Message);
            }

            if(ex is UnauthorizedException)
            {
                return Unauthorized(ex.Message);
            }

            if(ex is ValidationException)
            {
                return UnprocessableEntity($"{ex.Data.Keys},{ex.Data.Values}");
            }

            return BadRequest();
        }

        return await Task.FromResult(BadRequest());
    }
}
