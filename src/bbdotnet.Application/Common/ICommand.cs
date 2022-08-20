using ErrorOr;
using MediatR;

namespace bbdotnet.Application.Common
{
    internal interface ICommand<TResponse> : IRequest<ErrorOr<TResponse>>
    {
    }

    internal interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, ErrorOr<TResponse>>
        where TCommand : ICommand<TResponse>
    { 
    }
}
