using Microsoft.AspNetCore.Mvc;
using MyNotes.Data;
using MyNotes.Entities;
using MyNotes.Commands.Responses;
using MyNotes.Commands.Requests;
using MediatR;

namespace MyNotes.Controller;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase{

  private readonly IMediator _mediator;
  
  public UserController(IMediator mediator)
    => this._mediator = mediator;

  [HttpGet("{id}")]
  public async Task<User>getUser([FromRoute]Guid id)
    => await _mediator.Send(new GetUserByIdRequest(id));

  [HttpPost("login")]
  public async Task<LoginResponse> Login(
    [FromBody] LoginRequest loginRequest)
    => await _mediator.Send(loginRequest);
 
  [HttpPost]
  public async Task<CreateUserResponse>newUser(
      [FromBody] CreateUserRequest createUserRequest)
    => await _mediator.Send(createUserRequest);

  [HttpPatch("{id}/password")]
  public async Task<string>updatePassword(
      [FromRoute]Guid id,
      [FromBody]PasswordRequest request) 
    => await _mediator.Send(new ChangePasswordRequest(id, request.password, request.newPassword));
  
  [HttpDelete("{id}")]
  public async Task<string> deleteUser([FromRoute]Guid id)
    => await _mediator.Send(new DeleteUserRequest(id));

  // -- Notes --

  // list - create - update - delete


  [HttpGet("{id}/notes")]
  public async Task GetNotes(
      [FromRoute] Guid id
      ){}

  /*
  [HttpGet("{id}/notes/{noteId}")]
  public async Task GetNote(
      [FromRoute] string id,
      [FromRoute] string noteId
      ){}

  [HttpPost("{id}/notes")]
  public async Task newNote(
      [FromRoute] string id,
      [FromBody] CreateNoteRequest request
      ){}

  [HttpPut("{id}/notes")]
  public async Task newNote(
      [FromRoute] string id
      ){}

  [HttpDelete("{id}/notes/{noteId}")]
  public async Task newNote(
      [FromRoute] string id,
      [FromRoute] string noteId
      ){}
*/
}
