using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Users.Commands.Create;

namespace TajMaster.WebApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UserController(IMediator mediator) : ControllerBase
{
    [HttpPost] 
    public async Task<IActionResult> Create([FromBody] CreateUserCommand command, CancellationToken cancellationToken = default){
    {
        var commandResult = await mediator.Send(command, cancellationToken);
        return Ok(commandResult);
    }}
}