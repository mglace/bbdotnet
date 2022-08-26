using bbdotnet.Application.Posts.Commands;
using bbdotnet.Application.Topics.Commands;
using bbdotnet.WebApi.Models;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace bbdotnet.WebApi.Controllers
{
    [Route("api/topics/{topicId:int}/replies")]
    public class PostsController : ApiControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public PostsController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(int topicId, ReplyToTopicRequest request)
        {
            var command = _mapper.Map<ReplyToTopicCommand>((topicId, request));

            var result = await _sender.Send(command);

            return CreatedOrProblem(result, d => $"api/topics/{topicId}/posts/{d.Id}");
        }

        [HttpDelete("id:int")]
        public async Task<IActionResult> Delete(int topicId, int id)
        {
            var command = new RemovePostCommand(topicId, id);

            var result = await _sender.Send(command);

            return NoContentOrProblem(result);
        }
    }
}
