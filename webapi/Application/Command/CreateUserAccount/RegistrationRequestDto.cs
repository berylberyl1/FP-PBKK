namespace webapi.Application.Command.CreateUserAccount;

public class RegistrationRequestDto {
   public string? FullName { get; set; }
   public string? Email { get; set; }
   public string? Password { get; set; }
}