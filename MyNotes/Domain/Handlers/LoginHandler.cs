using MyNotes.Commands.Requests;
using MyNotes.Commands.Responses;
using MediatR;

namespace MyNotes.Commands.Handlers;

public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse> {

  private readonly DataContext _dataContext;

  public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken){
    return new LoginResponse{email="Oliver"};
  }
}
