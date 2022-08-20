using bbdotnet.Application;
using bbdotnet.Application.Topics.Queries;
using bbdotnet.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace bbdotnet.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TopicsController : ApiControllerBase
    {
        private readonly ISender _sender;

        public TopicsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]PagedRequest request)
        { 
            var query = new GetTopicsForCategoryQuery(1)
            { 
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            var result = await _sender.Send(query);

            return OkOrProblem(result);
        }

        [HttpPost]
        public Task<IActionResult> Post(CreateTopicRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id:int}")]
        public Task<IActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
