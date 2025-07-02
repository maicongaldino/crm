using System.ComponentModel.DataAnnotations;
using CRM.Application.Shared.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Api.Exceptions;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError(exception, "Uma exceção ocorreu: {Message}", exception.Message);

        var problemDetails = CreateProblemDetails(httpContext, exception);

        httpContext.Response.StatusCode = problemDetails.Status!.Value;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }

    private static ProblemDetails CreateProblemDetails(HttpContext httpContext, Exception exception)
    {
        var problemDetails = exception switch
        {
            NotFoundException ex => new ProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Title = "Recurso não encontrado.",
                Detail = ex.Message,
                Instance = httpContext.Request.Path
            },
            _ => new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Erro interno no servidor.",
                Detail = "Ocorreu um erro inesperado. Tente novamente mais tarde.",
                Instance = httpContext.Request.Path
            }
        };

        return problemDetails;
    }
}