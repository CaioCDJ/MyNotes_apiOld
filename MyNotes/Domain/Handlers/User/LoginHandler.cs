using Microsoft.AspNetCore.Mvc;
using MyNotes.Commands.Requests;
using MyNotes.Commands.Responses;
using MyNotes.Commands.Mapping;
using MyNotes.Repository;
using MediatR;

namespace MyNotes.Commands.Handlers;

public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse> {

  private readonly UserRepository _repository;

  public LoginHandler(DataContext dataContext)
    => this._repository  = new UserRepository(dataContext);

  public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken){

    var user = await _repository.GetLogin(request);

    //if(string.IsNullOrEmpty(verify.Id))

   var response = UserMapper.ToLoginResponse(user);

   return response;
  }

}
