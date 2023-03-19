using MyNotes.Entities;
using MyNotes.Repository;
using MediatR;
using MyNotes.Domain.Mapping;
using MyNotes.Domain.Commands.Requests;

namespace MyNotes.Domain.Commands.Handlers;

public class CreateNoteHandler : IRequestHandler<CreateNoteRequest,Note> {

  private readonly NotesRepository _notesRepository;
  private readonly UserRepository _userRepository;

  public CreateNoteHandler(DataContext dataContext){
    this._notesRepository  = new NotesRepository(dataContext);
    this._userRepository  = new UserRepository(dataContext);
  }
  public async Task<Note> Handle(CreateNoteRequest request, CancellationToken cancellationToken){
   
    var newNote = NoteMapper.CreateNoteToNote(request);

    await _notesRepository.Add(newNote);

    return await _notesRepository.GetNote(newNote.Id, newNote.userId);
  }
}
