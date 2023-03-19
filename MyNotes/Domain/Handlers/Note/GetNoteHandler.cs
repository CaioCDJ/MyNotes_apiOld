using MyNotes.Entities;
using MyNotes.Repository;
using MediatR;
using MyNotes.Domain.Mapping;
using MyNotes.Domain.Queries.Requests;

namespace MyNotes.Domain.Commands.Handlers;

public class GetNoteHandler : IRequestHandler<GetNoteRequest,Note> {

  private readonly NotesRepository _notesRepository;

  public GetNoteHandler(DataContext dataContext)
    => this._notesRepository  = new NotesRepository(dataContext);  

  public async Task<Note> Handle(GetNoteRequest request, CancellationToken cancellationToken){

    return await _notesRepository.GetNote(request.id, request.userId);
  }
}
