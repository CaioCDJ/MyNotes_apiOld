using Microsoft.AspNetCore.Mvc;
using MyNotes.Commands.Handlers;
using MyNotes.Commands.Responses;
using MyNotes.Commands.Requests;

namespace MyNotes.Controller;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase{

  public async Task<IResult> Login(
    [FromBody] LoginRequest loginRequest
  ){
    return Results.Ok();
  }

}
