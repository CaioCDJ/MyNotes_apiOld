using MyNotes.Entities;
using MyNotes.Commands.Responses;
using MyNotes.Commands.Requests;

namespace MyNotes.Commands.Mapping;

public class UserMapper{

  public static User CreateUserResponseToUser(CreateUserRequest createUserResponse)
    => new User(){
      name = createUserResponse.name,
      email = createUserResponse.email,
      password = createUserResponse.password,
    };

  // -- Responses --

  public static CreateUserResponse ToCreateUserResponse(User user)
    => new CreateUserResponse(){
      Id = user.Id,
      name = user.name,
      email = user.email,
    };

  public static LoginResponse ToLoginResponse(User user)
    => new LoginResponse(){
      Id = user.Id,
      name = user.name,
      email = user.email,
      createdAt = user.createdAt
    };
}
