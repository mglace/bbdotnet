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
    }
}
