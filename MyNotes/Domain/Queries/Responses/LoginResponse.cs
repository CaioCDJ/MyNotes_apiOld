
namespace MyNotes.Domain.Queries.Responses;

public class LoginResponse{
  public string Id { get; set; }
  public string name { get; set; }
  public string email { get; set; }
  public DateTime createdAt { get; set; }
  public string token { get; set; }
}

