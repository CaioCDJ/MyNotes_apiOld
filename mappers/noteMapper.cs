
namespace MyNotes_api.Entities;

public class NoteMapper{
  public static Note toNote(noteDTO dto){
   return new Note(){
    title = dto.title,
    note = dto.text
   };
  }
}
