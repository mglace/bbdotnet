using System.Net;

namespace bbdotnet.WebApi.Models;
internal class ErrorResponse
{
    public HttpStatusCode StatusCode { get; set; }

    public string Message { get; set; } = default!;

    public static readonly ErrorResponse BadRequest = new ErrorResponse
    { 
        StatusCode = HttpStatusCode.BadRequest,
        Message = "Bad Request"
    };
}
