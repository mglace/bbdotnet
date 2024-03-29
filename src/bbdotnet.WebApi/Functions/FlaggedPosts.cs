using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace bbdotnet.WebApi.Functions;

public class FlaggedPosts
{
    private readonly ILogger _logger;

    public FlaggedPosts(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<FlaggedPosts>();
    }

    [Function("GetFlaggedPosts")]
    public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "flagged-posts")] HttpRequestData req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        var response = req.CreateResponse(HttpStatusCode.OK);

        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

        response.WriteString("Welcome to Azure Functions!");

        return response;
    }
}
