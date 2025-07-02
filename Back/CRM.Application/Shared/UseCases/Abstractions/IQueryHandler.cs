namespace CRM.Application.Shared.UseCases.Abstractions;

public interface IQueryHandler<in TQuery, TResponse>
    where TQuery : IQuery
    where TResponse : IQueryResponse
{
    Task<TResponse> HandleAsync(TQuery query);
}