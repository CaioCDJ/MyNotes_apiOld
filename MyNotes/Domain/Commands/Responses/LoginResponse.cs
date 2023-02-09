
namespace MyNotes.Commands.Responses;

public record LoginResponse{

  public Guid Id { get; set; }

  public string name { get; set; }
  
  public string email { get; set; }
  
  public string password { get; set; }

  public DateTime createdAt { get; set; }

  public string token { get; set; }

}
