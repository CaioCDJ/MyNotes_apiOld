using MyNotes.Commands.Requests;
using MyNotes.Commands.Responses;

namespace MyNotes.Commands.Handlers;

public class LoginHandler : ILoginHandler {

  public async Task<LoginResponse> Handle(LoginRequest loginRequest){
     
    return new LoginResponse{ name = " Oliver the boxer" };
  }
}
