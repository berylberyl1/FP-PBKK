namespace webapi.Controllers;

using Microsoft.AspNetCore.Mvc;
using webapi.Application.Command.CreateUserAccount;
using webapi.Application.Command.LogIn;
using webapi.Domain.Account.Repository;

[ApiController]
[Route("Auth")]
public class AuthenticationController : ControllerBase {
    CreateUserAccountCommand createUserCommand;
    LogInCommand logInCommand;

    public AuthenticationController(
        ILogger<LogInCommand> logger,
        IConfiguration configuration,
        IUserRepository repository
    ){
        this.createUserCommand = new CreateUserAccountCommand(repository);
        this.logInCommand = new LogInCommand(logger, configuration, repository);
    }

    [HttpPost("SignUp")]
    public IActionResult SignUp([FromBody] RegistrationRequestDto request) {
        try {
            createUserCommand.Handle(request);
        }
        catch (InvalidOperationException e) {
            return BadRequest(new {
                EmailError = e.Message
            });
        }

        return Ok();
    }

    [HttpPost("LogIn")]
    public IActionResult LogIn([FromBody] LogInDto request) {
        string token = "";
        try {
            token = logInCommand.Handle(request);
        }
        catch (InvalidOperationException e) {
            return BadRequest(new {
                EmailError = e.Message
            });
        }

        return Ok(new {
            Token = token
        });
    }
}
