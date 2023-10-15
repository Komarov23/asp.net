using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Text;
using System.Threading.Tasks;

public class ErrorLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public ErrorLoggingMiddleware(RequestDelegate next, ILogger<ErrorLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Помилка: {ex}");

            try
            {
                string logMessage = $"{DateTime.Now} - Помилка: {ex}\n";
                File.AppendAllText("errors.log", logMessage, Encoding.UTF8);
            }
            catch (Exception logEx)
            {
                _logger.LogError($"Помилка при записі до журналу: {logEx}");
            }

            throw;
        }
    }
}

public static class ErrorLoggingMiddlewareExtensions
{
    public static IApplicationBuilder UseErrorLoggingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ErrorLoggingMiddleware>();
    }
}
