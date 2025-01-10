using System.IdentityModel.Tokens.Jwt;

namespace TajMaster.WebApi.Middleware;

public class RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
{
    private readonly ILogger _logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation("Request: {Method} {Path}", 
            context.Request.Method, 
            context.Request.Path);

        if (context.Request.Headers.ContainsKey("Authorization"))
        {
            var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
                
                _logger.LogInformation("Token Details:");
                _logger.LogInformation("Issuer: {Issuer}", jsonToken?.Issuer);
                _logger.LogInformation("Valid From: {ValidFrom}", jsonToken?.ValidFrom);
                _logger.LogInformation("Valid To: {ValidTo}", jsonToken?.ValidTo);
                _logger.LogInformation("Claims: {Claims}", 
                    string.Join(", ", jsonToken?.Claims.Select(c => $"{c.Type}: {c.Value}") ?? Array.Empty<string>()));
            }
            catch (Exception ex)
            {
                _logger.LogError("Error parsing token: {Error}", ex.Message);
            }
        }

        await next(context);
        
        _logger.LogInformation("Response Status Code: {StatusCode}", 
            context.Response.StatusCode);
    }
}