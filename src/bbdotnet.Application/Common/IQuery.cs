using ErrorOr;
using MediatR;

namespace bbdotnet.Application.Common
{
    public interface IQuery<TResponse> : IRequest<ErrorOr<TResponse>>
    {
    }

    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, ErrorOr<TResponse>>
        where TQuery : IQuery<TResponse>
    { 
    }
}
