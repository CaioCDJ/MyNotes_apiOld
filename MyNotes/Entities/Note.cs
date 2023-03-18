using System.ComponentModel.DataAnnotations;

namespace MyNotes.Entities;

public class Note{

  [Key]
  public string Id { get; set; } = Guid.NewGuid().ToString();

  public string title { get; set; }
  
  public string text { get; set; }
  
  public DateTime createdAt { get; set; } = DateTime.Now;
  
  public DateTime updatedAt { get; set; }

  public User user { get; set; }

  public Guid userId { get; set; }

}
