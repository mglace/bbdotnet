using Azure;
using MediatR;

namespace bbdotnet.Application.Abstractions;

internal interface ICommand : ICommand<Result> { }

internal interface ICommand<TResponse> : IRequest<Result<TResponse>> { }

internal interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand
{ }

internal interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
{ }
