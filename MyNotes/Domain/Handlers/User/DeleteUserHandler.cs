using MyNotes.Commands.Requests;
using MyNotes.Commands.Responses;
using MyNotes.Commands.Mapping;
using MyNotes.Repository;
using MyNotes.Security;
using MediatR;

namespace MyNotes.Commands.Handlers;

public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, string> {

  private readonly UserRepository _repository;

  public DeleteUserHandler(DataContext dataContext)
    => this._repository  = new UserRepository(dataContext);

  public async Task<string> Handle(DeleteUserRequest request, CancellationToken cancellationToken){
    
    var user = await _repository.GetById(request.id.ToString());

    if(user is not null){
      await _repository.remove(user.Id);
      return $"A conta do usuario {user.name} foi excluida com sucesso";
    }
    else
      return "Error myy friend";
  }
}
