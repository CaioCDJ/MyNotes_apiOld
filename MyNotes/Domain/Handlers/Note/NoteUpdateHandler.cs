using MyNotes.Domain.Commands.Requests;
using MyNotes.Domain.Commands.Responses;
using MyNotes.Domain.Mapping;
using MyNotes.Entities;
using MyNotes.Repository;
using MediatR;

namespace MyNotes.Domain.Handlers;

public class NoteUpdateHandler : IRequestHandler<NoteUpdateRequest,Note>{

  private readonly NotesRepository _noteRepository;
  private readonly UserRepository _userRepository;

  public NoteUpdateHandler(DataContext dataContext){
    _noteRepository = new NotesRepository(dataContext);
    _userRepository = new UserRepository(dataContext);
  }

  public async Task<Note>Handle(NoteUpdateRequest request,CancellationToken CancellationToken){

    var user = await _userRepository.GetById(request.userId);

    if(user is not null){

      var note = await _noteRepository.GetNote(request.id, request.userId);
  
      if(note is not null){
        note.title = request.title;
        note.text = request.text;
        note.updatedAt = DateTime.Now;

        await _noteRepository.Update(note);

        return note;
      } 
      else
        return null; // null || empty = error
    }

    return new Note();
  }

}
