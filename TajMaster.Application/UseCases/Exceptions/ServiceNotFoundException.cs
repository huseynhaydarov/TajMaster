using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.Users.Exceptions;

public class ServiceNotFoundException(string message)
    : NotFoundException(message, null!);