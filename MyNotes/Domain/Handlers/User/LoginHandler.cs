using MyNotes.Commands.Requests;
using MyNotes.Commands.Responses;
using MyNotes.Commands.Mapping;
using MyNotes.Repository;
using MyNotes.Security;
using MediatR;

namespace MyNotes.Commands.Handlers;

public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse> {

  private readonly UserRepository _repository;

  public LoginHandler(DataContext dataContext)
    => this._repository  = new UserRepository(dataContext);

  public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken){
  
    string password = await Hashing.ToSha(request.password);

    var user = await _repository.GetLogin(new LoginRequest(request.email, password));
    
    var response = UserMapper.ToLoginResponse(user);

    return response;
  }

}
