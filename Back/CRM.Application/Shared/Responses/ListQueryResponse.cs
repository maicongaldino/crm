using CRM.Application.Shared.UseCases.Abstractions;

namespace CRM.Application.Shared.Responses;

public class ListQueryResponse<T>(IEnumerable<T> items) : IQueryResponse
{
    public IEnumerable<T> Items { get; } = items;
}