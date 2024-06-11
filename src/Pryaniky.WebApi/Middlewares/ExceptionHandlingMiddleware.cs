using System.Text.Json;
using System.Text.Json.Serialization;
using Pryaniky.Data;

namespace Pryaniky.WebApi;

public sealed class ExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) => _logger = logger;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);

            await HandleExceptionAsync(context, e);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        httpContext.Response.ContentType = System.Net.Mime.MediaTypeNames.Application.Json;

        var statusCode = GetStatusCode(exception);

        var response = new
        {
            Title = GetTitle(exception),
            Status = statusCode,
        };

        httpContext.Response.StatusCode = statusCode;

        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response, JsonSerializerOptions));

    }

    private static int GetStatusCode(Exception exception)
    {
        return exception switch
        {
            NotFoundByIdException => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };
    }

    private static string GetTitle(Exception exception) =>
        exception switch
        {
            NotFoundByIdException => "Not Found",
            _ => "Server Error"
        };
}