
namespace MyNotes.Commands.Requests;

public record LoginRequest{
  public string email { get; set; }
  public string password { get; set; }
}
