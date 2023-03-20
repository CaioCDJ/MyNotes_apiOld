using MyNotes.Domain.Commands.Requests;
using MyNotes.Domain.Commands.Responses;
using MyNotes.Entities;
using MyNotes.Repository;
using MediatR;

namespace MyNotes.Domain.Handlers;

public class DeleteNoteHandler : IRequestHandler<DeleteNoteRequest, string>{
  
  private readonly NotesRepository _notesRepository;

  public DeleteNoteHandler(DataContext dataContext)
    => _notesRepository = new NotesRepository(dataContext);

  public async Task<string> Handle(DeleteNoteRequest request, CancellationToken cancellationToken){

    var note = await _notesRepository.GetNote(request.id, request.userId);

    if(note.Id is not null){
      await _notesRepository.delete(note);
      return $"{note.title} foi removido com sucesso!";
    }
    else
      return null;

  }
}
