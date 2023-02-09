
namespace MyNotes.Entities;

public class Note{

  public Guid Id { get; set; }

  public string title { get; set; }
  
  public string text { get; set; }
  
  public DateTime createdAt { get; set; } = DateTime.Now;
  
  public DateTime cpdatedAt { get; set; }
}
