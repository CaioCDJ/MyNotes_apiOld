
namespace MyNotes.Commands.Requests;

public record CreateUserRequest{
  
  public string name { get; set; }
  
  public string email { get; set; }
  
  public string password { get; set; }
}
