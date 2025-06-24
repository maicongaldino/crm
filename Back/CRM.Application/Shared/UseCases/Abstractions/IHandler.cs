namespace CRM.Application.Shared.UseCases.Abstractions;

public interface IHandler<in TCommand, TResponse>
    where TCommand : ICommand
    where TResponse : IResponse
{
    Task<TResponse> HandleAsync(TCommand command);
}