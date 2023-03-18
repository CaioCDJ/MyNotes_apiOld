using MyNotes.Commands.Requests;
using MyNotes.Commands.Responses;
using MyNotes.Commands.Mapping;
using MyNotes.Repository;
using MediatR;
using MyNotes.Security;

namespace MyNotes.Commands.Handlers;

public class NewUserHandler : IRequestHandler<CreateUserRequest,CreateUserResponse>{
  
  private readonly UserRepository _userRepository;

  public NewUserHandler(DataContext dataContext){
    this._userRepository = new UserRepository(dataContext);
  }

  public async Task<CreateUserResponse> Handle(CreateUserRequest request,CancellationToken cancellationToken){

    var user = UserMapper.CreateUserResponseToUser(request);
  
    user.password = await Hashing.ToSha(request.password); 
    
    await _userRepository.Add(user);

    return UserMapper.ToCreateUserResponse(user);
  }
}
