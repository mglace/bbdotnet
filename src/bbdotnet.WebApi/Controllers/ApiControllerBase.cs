using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace bbdotnet.WebApi.Controllers
{
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        protected IActionResult OkOrProblem<TData>(ErrorOr<TData> result)
        { 
            return result.MatchFirst( 
                d => Ok(d),
                e => Problem(statusCode: StatusCodes.Status500InternalServerError, detail: e.Description));
        }

        protected IActionResult CreatedOrProblem<TData>(ErrorOr<TData> result, Func<TData, string> uriFunc)
        {
            return result.MatchFirst(
                d => Created(uriFunc(d), d),
                e => Problem(statusCode: StatusCodes.Status500InternalServerError, detail: e.Description));
        }

        protected IActionResult NoContentOrProblem<TData>(ErrorOr<TData> result)
        {
            return result.MatchFirst<IActionResult>(
                _ => NoContent(),
                e => Problem(statusCode: StatusCodes.Status500InternalServerError, detail: e.Description));
        }
    }
}
