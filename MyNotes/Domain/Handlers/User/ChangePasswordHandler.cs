using MyNotes.Repository;
using MyNotes.Security;
using MediatR;
using MyNotes.Domain.Commands.Requests;

namespace MyNotes.Domain.Commands.Handlers;

public class ChangePasswordHandler : IRequestHandler<ChangePasswordRequest, string>{

  private readonly UserRepository _userRepository;

  public ChangePasswordHandler(DataContext dataContext)
    => _userRepository = new UserRepository(dataContext);

  public async Task<string> Handle(ChangePasswordRequest request, CancellationToken cancellationToken){

    var user = await _userRepository.GetById(request.id.ToString());
   
    bool passwordHashCompare = await Hashing.Compare(user.password, request.password);
    
    if(passwordHashCompare){
      
      user.password = await Hashing.ToSha(request.newPassword);
      
      await _userRepository.Update(user);
      
      return $"A senha foi alterada com sucesso";
    }
    else
      return "erro" ; // sim, eu sei que vai retornar como codigo 200
  }

}
