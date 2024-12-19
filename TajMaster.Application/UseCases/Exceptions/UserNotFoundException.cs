using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.Users.Exceptions;

public class UserNotFoundException(string message)
    : NotFoundException(message, null!);