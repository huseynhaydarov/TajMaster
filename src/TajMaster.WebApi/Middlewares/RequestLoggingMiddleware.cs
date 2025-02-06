using System.IdentityModel.Tokens.Jwt;

namespace TajMaster.WebApi.Middlewares;

public class RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        logger.LogInformation("Request: {Method} {Path}", context.Request.Method, context.Request.Path);

        if (context.Request.Headers.ContainsKey("Authorization"))
        {
            var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            try
            {
                var handler = new JwtSecurityTokenHandler();

                if (handler.ReadToken(token) is JwtSecurityToken jsonToken)
                {
                    logger.LogInformation("Token Details:");
                    logger.LogInformation("Issuer: {Issuer}", jsonToken.Issuer);
                    logger.LogInformation("Valid From: {ValidFrom}", jsonToken.ValidFrom);
                    logger.LogInformation("Valid To: {ValidTo}", jsonToken.ValidTo);

                    var claims = string.Join(", ", jsonToken.Claims.Select(c => $"{c.Type}: {c.Value}"));
                    logger.LogInformation("Claims: {Claims}", claims);
                }
                else
                {
                    logger.LogWarning("Token parsing failed. Token is null.");
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Error parsing token: {Error}", ex.Message);
            }
        }

        await next(context);

        logger.LogInformation("Response Status Code: {StatusCode}", context.Response.StatusCode);
    }
}