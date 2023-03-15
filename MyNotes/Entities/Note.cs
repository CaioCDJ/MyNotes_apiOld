using System.ComponentModel.DataAnnotations;

namespace MyNotes.Entities;

public class Note{

  [Key]
  public Guid Id { get; set; }

  public string title { get; set; }
  
  public byte[] text { get; set; }
  
  public DateTime createdAt { get; set; } = DateTime.Now;
  
  public DateTime updatedAt { get; set; }

  public User user { get; set; }

  public Guid userId { get; set; }

}
