
namespace MyNotes.Domain.Commands.Responses;

public record CreateUserResponse{
  public string Id { get; set; } 
  public string name { get; set; }
  public string email { get; set; }
  public string token { get; set; }
}
