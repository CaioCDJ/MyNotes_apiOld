using MyNotes.Commands.Requests;
using MyNotes.Commands.Responses;

namespace MyNotes.Commands.Handlers;

public interface ILoginHandler{

  public Task<LoginResponse> Handle(LoginRequest loginRequest);
}
