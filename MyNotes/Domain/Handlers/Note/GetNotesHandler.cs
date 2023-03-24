using MyNotes.Domain.Queries.Requests;
using MyNotes.Domain.Queries.Responses;
using MyNotes.Repository;
using MediatR;

namespace MyNotes.Domain.Handlers;

public class GetNotesHandler : IRequestHandler<GetNotesRequest, IEnumerable<GetNotesResponse>>{

  private readonly NotesRepository _notesRepository;

  public GetNotesHandler(DataContext dataContext)
    => _notesRepository = new NotesRepository(dataContext);

  public async Task<IEnumerable<GetNotesResponse>>Handle(GetNotesRequest request, CancellationToken cancellationToken){
    
    var list = await _notesRepository.GetNotes(request.userId); 
    
    var lista =  list.ToList();

    return list;
  }
}

