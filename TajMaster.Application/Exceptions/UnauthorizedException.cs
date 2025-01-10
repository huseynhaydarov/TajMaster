namespace TajMaster.Application.Exceptions;

public class UnauthorizedException : Exception
{
    public UnauthorizedException() 
        : base("Unauthorized access") { }
    
    public UnauthorizedException(string message) 
        : base(message) { }
    
    public UnauthorizedException(string message, Exception innerException)
        : base(message, innerException) { }
    
    public int StatusCode { get; set; } = 401; // Default to HTTP 401 Unauthorized
}