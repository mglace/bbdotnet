using bbdotnet.Application.Abstractions;
using bbdotnet.Application.Behaviors.Validation;
using bbdotnet.Domain.Shared;
using bbdotnet.WebApi.Models;
using Grpc.Core;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;

namespace bbdotnet.WebApi;

internal static class HttpRequestExtensions 
{
    public static Task<HttpResponseData> OkOrProblemAsync<T>(this HttpRequestData req, Result<T> result) =>
        result.IsFailure ?
            req.ProblemAsync(result) :
            req.OkAsync(result.Value);

    public static async Task<HttpResponseData> OkAsync<T>(this HttpRequestData req, T data)
    {
        var res = req.CreateResponse(HttpStatusCode.OK);

        await res.WriteAsJsonAsync(data);

        return res;
    }

    public static async Task<HttpResponseData> ProblemAsync(this HttpRequestData req, HttpStatusCode statusCode, string description)
    {
        var res = req.CreateResponse(statusCode);
        
        await res.WriteAsJsonAsync(ErrorResponse.BadRequest);

        return res;
    }

    public static Task<HttpResponseData> ProblemAsync(this HttpRequestData req, Result result) =>
        result switch
        {
            { IsSuccess: true } => throw new InvalidOperationException(),
            IValidationResult validationResult =>
                req.CreateProblemResponse(
                    HttpStatusCode.BadRequest,
                    "Validation Error",
                    result.Error,
                    validationResult.Errors),
            _ => 
                req.CreateProblemResponse(
                    HttpStatusCode.InternalServerError,
                    "Unknown Error Occurred",
                    result.Error)
        };

    private static async Task<HttpResponseData> CreateProblemResponse(
        this HttpRequestData req,
        HttpStatusCode status,
        string title,
        Error error,
        Error[]? errors = null)
    { 
        var response = req.CreateResponse(status);

        var body = new ProblemDetails
        {
            Title = title,
            Type = error.Code,
            Detail = error.Message,
            Status = (int)status,
            Extensions = { { nameof(errors), errors } }
        };

        await response.WriteAsJsonAsync(body);

        return response;
    }
}
