namespace Core.Presentation;

using System.ComponentModel.DataAnnotations;
using Core.Domain;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, 
        Exception exception, 
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "An unhandled exception occurred: {Message}", exception.Message);

        var (statusCode, title) = exception switch
        {
            Domain.ValidationException => (StatusCodes.Status400BadRequest, "Invalid request body"),
            Domain.InvalidStateTransitionException => (StatusCodes.Status400BadRequest, "Invalid operation"),
            DomainException => (StatusCodes.Status400BadRequest, "Business rules violation"),
            _ => (StatusCodes.Status500InternalServerError, "An error occurred while processing your request.")
        };

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = exception.Message,
            Instance = httpContext.Request.Path
        };

        httpContext.Response.StatusCode = statusCode;
        
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true; 
    }
}