using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TajMaster.Application.Exceptions;

namespace TajMaster.Infrastructure.Middlewares;

public class CustomExceptionHandlerMiddleware(
    RequestDelegate next,
    ILogger<CustomExceptionHandlerMiddleware> logger,
    IWebHostEnvironment env)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        logger.LogError(exception, "Unhandled exception occurred. TraceId: {TraceId}", httpContext.TraceIdentifier);

        (string Detail, string Title, int StatusCode) details;

        if (exception is ValidationException validationException)
            details = (
                validationException.Message,
                "Validation Error",
                StatusCodes.Status400BadRequest
            );
        else
            details = exception switch
            {
                InternalServerException => (
                    exception.Message,
                    "Internal Server Error",
                    StatusCodes.Status500InternalServerError
                ),
                BadRequestException => (
                    exception.Message,
                    "Bad Request",
                    StatusCodes.Status400BadRequest
                ),
                NotFoundException => (
                    exception.Message,
                    "Resource Not Found",
                    StatusCodes.Status404NotFound
                ),
                ConflictException => (
                    exception.Message,
                    "Conflict",
                    StatusCodes.Status409Conflict
                ),
                _ => (
                    env.IsDevelopment() ? exception.ToString() : "An unexpected error occurred.",
                    "Internal Server Error",
                    StatusCodes.Status500InternalServerError
                )
            };

        var problemDetails = new ProblemDetails
        {
            Title = details.Title,
            Detail = details.Detail,
            Status = details.StatusCode,
            Instance = httpContext.Request.Path
        };

        problemDetails.Extensions.Add("traceId", httpContext.TraceIdentifier);
        if (exception is ValidationException validationEx)
            problemDetails.Extensions.Add("ValidationErrors", validationEx.Errors);

        var response = env.IsDevelopment()
            ? JsonSerializer.Serialize(problemDetails, new JsonSerializerOptions { WriteIndented = true })
            : JsonSerializer.Serialize(new
            {
                details.StatusCode,
                details.Title,
                TraceId = httpContext.TraceIdentifier
            });

        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = details.StatusCode;

        await httpContext.Response.WriteAsync(response);
    }
}