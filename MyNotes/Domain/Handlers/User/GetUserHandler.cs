using MyNotes.Entities;
using MyNotes.Repository;
using MediatR;
using MyNotes.Domain.Queries.Requests;

namespace MyNotes.Domain.Commands.Handlers;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, User> {

  private readonly UserRepository _userRepository;

  public GetUserByIdHandler(DataContext dataContext)
    => _userRepository = new UserRepository(dataContext);

  public async Task<User> Handle(GetUserByIdRequest request, CancellationToken cancellationToken){
  
    var user = await _userRepository.GetById(request.id);

    return user;
  }
}
