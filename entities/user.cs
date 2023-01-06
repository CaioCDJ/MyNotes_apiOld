
namespace MyNotes_api.Entities; 

public class User{

  public Guid id{ get; set; }
  
  public string? name { get; set; }
  
  public string? email { get; set; }
  
  public string? password { get; set; }

  public DateTime? created_at { get; set; }
  
  public List<Note>? notes { get; set; }
}
