using System.ComponentModel.DataAnnotations;

namespace MyNotes.Entities;

public class User{

  [Key]
  public Guid Id { get; set; }

  public string name { get; set; }
  
  public string email { get; set; }
  
  public string password { get; set; }

  public DateTime createdAt { get; set; } = DateTime.Now;

}
