using MyNotes.Domain.Queries.Request;
using MyNotes.Domain.Queries.Responses;
using MyNotes.Domain.Commands.Requests;
using MyNotes.Entities;

namespace MyNotes.Domain;

public class NoteMapper{

  public static Note CreateNoteToNote(CreateNoteRequest request)
    => new Note(){
      title = request.title,
      text = "Evolua o "+ request.title,
      userId = request.userId,
    };
}
