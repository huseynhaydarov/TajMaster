using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.Users.Exceptions;

public class UserNotFoundException(int id) : NotFoundException("User", id);