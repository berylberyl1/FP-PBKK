namespace webapi.Application.Command.LogIn;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using webapi.Domain.Account.Model;
using webapi.Domain.Account.Repository;

public class LogInCommand {
    IConfiguration configuration;
    IUserRepository repository;
    ILogger<LogInCommand> logger;

    public LogInCommand(
        ILogger<LogInCommand> logger,
        IConfiguration configuration,
        IUserRepository repository
    ) {
        this.logger = logger;
        this.configuration = configuration;
        this.repository = repository;
    }

    public string Handle(LogInDto request) {
        if(request.Email == null) throw new InvalidOperationException("User credentials incorrect.");
        if(request.Password == null) throw new InvalidOperationException("User credentials incorrect.");

        User? user = repository.GetFirst(request.Email, request.Password);
        if(user == null) throw new InvalidOperationException("User credentials incorrect.");

        User newUser = new User() {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
        };

        return GenerateToken(user);
    }

    string GenerateToken(User user) {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? ""));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        if(user.Email == null) return "";
        if(user.FullName == null) return "";

        var expiration = DateTime.Now.AddMinutes(60);

        var claims = new[] {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.FullName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Expiration, expiration.ToString())
        };

        var token = new JwtSecurityToken(
            configuration["Jwt:Issuer"],
            configuration["Jwt:Audience"],
            claims,
            expires: expiration,
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}