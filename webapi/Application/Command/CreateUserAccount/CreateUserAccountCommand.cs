namespace webapi.Application.Command.CreateUserAccount;

using webapi.Domain.Account.Model;
using webapi.Domain.Account.Repository;

public class CreateUserAccountCommand {
    IUserRepository repository;

    public CreateUserAccountCommand(
        IUserRepository repository
    ) {
        this.repository = repository;
    }

    public async Task Handle(RegistrationRequestDto request) {
        await foreach(User user in repository.GetAll()) {
            if(user.Email == request.Email) {
                throw new InvalidOperationException("Email already exists.");
            }
        }

        User newUser = new User() {
            FullName = request.FullName,
            Email = request.Email,
            Password = request.Password
        };

        await repository.Add(newUser);
    }
}