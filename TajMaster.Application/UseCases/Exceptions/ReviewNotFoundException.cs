using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.Users.Exceptions;

public class ReviewNotFoundException(string message)
    : NotFoundException(message, null!);