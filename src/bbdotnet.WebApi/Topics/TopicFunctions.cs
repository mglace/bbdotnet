using MediatR;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker;
using bbdotnet.Application.Topics.Queries;
using bbdotnet.Application.Topics.Commands;
using System.Net;
using bbdotnet.Domain;

namespace bbdotnet.WebApi.Topics; 

public class TopicFunctions
{
    private readonly ISender _sender;

    public TopicFunctions(ISender sender)
    {
        _sender = sender;
    }

    [Function("Topics_Get")]
    public async Task<HttpResponseData> GetTopics(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "topics")] HttpRequestData req) 
    {
        var query = new GetPagedTopicsQuery(1);

        var result = await _sender.Send(query);

        return await req.OkOrProblemAsync(result);
    }

    [Function("Topics_Create")]
    public async Task<HttpResponseData> CreateTopic(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", "put", Route = "topics")] HttpRequestData req)
    {
        var request = await req.ReadFromJsonAsync<CreateTopicRequest>();

        if (request is null)
        { 
            return await req.ProblemAsync(HttpStatusCode.BadRequest, "");
        }

        var query = new CreateTopicCommand(
            request.Title, 
            request.Body, 
            request.CategoryId,
            Enumerable.Empty<TagId>());

        var result = await _sender.Send(query);

        return await req.OkOrProblemAsync(result);
    }
}
