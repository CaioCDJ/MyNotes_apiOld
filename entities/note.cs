
namespace MyNotes_api.Entities;

public class Note{

  public Guid id { get; set; }
  
  public string? title{ get; set; }
  
  public string? note{ get; set; }
  
  public DateTime? created_at{ get; set; }
  
  public DateTime? updated_at{ get; set; }

  public Guid user_id { get; set; }

  public User? user{ get; set;}

  public Note(){
    this.id = Guid.NewGuid();
    this.created_at = DateTime.Now;
  }
}
