namespace webapi.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Application.Command.CreateUserAccount;
using webapi.Application.Command.LogIn;
using webapi.Domain.Account.Repository;

[ApiController]
[Route("api/Auth")]
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

    [AllowAnonymous]
    [HttpPost("SignUp")]
    public async Task<IActionResult> SignUp([FromBody] RegistrationRequestDto request) {
        try {
            await createUserCommand.Handle(request);
        }
        catch (InvalidOperationException e) {
            return BadRequest(new {
                EmailError = e.Message
            });
        }

        return Ok();
    }

    [AllowAnonymous]
    [HttpPost("LogIn")]
    public async Task<IActionResult> LogIn([FromBody] LogInDto request) {
        string token = "";
        try {
            token = await logInCommand.Handle(request);
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
