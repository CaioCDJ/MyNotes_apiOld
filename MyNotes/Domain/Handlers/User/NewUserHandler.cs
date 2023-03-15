using MyNotes.Commands.Requests;
using MyNotes.Commands.Responses;
using MyNotes.Commands.Mapping;
using MyNotes.Repository;
using MediatR;

namespace MyNotes.Commands.Handlers;

public class NewUserHandler : IRequestHandler<CreateUserRequest,CreateUserResponse>{
  
  private readonly DataContext _dataContext;

  public NewUserHandler(DataContext dataContext){
    this._dataContext = dataContext;
  }

  public async Task<CreateUserResponse> Handle(CreateUserRequest request,CancellationToken cancellationToken){

    UserRepository userRepository = new UserRepository(_dataContext);

    var user = UserMapper.CreateUserResponseToUser(request);

    await userRepository.Add(user);

    return UserMapper.ToCreateUserResponse(user);
  }

}
