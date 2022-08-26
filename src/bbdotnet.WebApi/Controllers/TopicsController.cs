using bbdotnet.Application.Topics.Commands;
using bbdotnet.Application.Topics.Queries;
using bbdotnet.WebApi.Models;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace bbdotnet.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TopicsController : ApiControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public TopicsController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates a new Topic
        /// </summary>
        /// <param name="request"></param>
        /// <returns>The newly created topic</returns>
        [HttpPost]
        public async Task<IActionResult> Post(CreateTopicRequest request)
        {
            var command = _mapper.Map<CreateTopicCommand>(request);

            var result = await _sender.Send(command);

            return CreatedOrProblem(result, d => $"api/topics/{d.Id}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public Task<IActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
