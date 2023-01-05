
namespace MyNotes_api.Entities;

public class Note{

  public Guid id { get; set; }
  
  public string title{ get; set; }
  
  public string text{ get; set; }
  
  public DateTime created_at{ get; set; }
  
  public DateTime updated_at{ get; set; }

}
