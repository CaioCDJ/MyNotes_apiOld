
namespace MyNotes.Commands.Responses;


public class LoginResponse{
  public string Id { get; set; }
  public string name { get; set; }
  public string email { get; set; }
  public string password { get; set; }
  public DateTime createdAt { get; set; }
  public string token { get; set; }
}

