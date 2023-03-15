using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace bbdotnet.WebApi.Posts;

public class PostFunctions
{
    private readonly ILogger _logger;

    public PostFunctions(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<PostFunctions>();
    }

    [Function("Posts_Get")]
    public HttpResponseData GetPosts([HttpTrigger(AuthorizationLevel.Function, "get", Route = "posts")] HttpRequestData req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

        response.WriteString("Welcome to Azure Functions!");

        return response;
    }
}
