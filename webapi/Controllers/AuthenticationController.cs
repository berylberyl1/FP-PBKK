namespace webapi.Controllers;

using Microsoft.AspNetCore.Mvc;
using webapi.Application.Command.CreateUserAccount;
using webapi.Domain.Account.Repository;

[ApiController]
[Route("Auth")]
public class AuthenticationController : ControllerBase {
    CreateUserAccountCommand createUserCommand;

    public AuthenticationController(
        IUserRepository repository
    ){
        this.createUserCommand = new CreateUserAccountCommand(repository);
    }

    [HttpPost]
    public IActionResult SignUp([FromBody] RegistrationRequestDto request) {
        try {
            createUserCommand.Handle(request);
        }
        catch (InvalidOperationException e) {
            return BadRequest(e.Data);
        }

        return Ok();
    }
}
