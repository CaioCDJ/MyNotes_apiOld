
namespace MyNotes.Commands.Responses;

public record CreateUserResponse{
  public Guid Id { get; set; } 
  public string name { get; set; }
  public string email { get; set; }
  public string token { get; set; }
}
