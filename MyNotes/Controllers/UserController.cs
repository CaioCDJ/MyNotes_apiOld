using Microsoft.AspNetCore.Mvc;
using MyNotes.Entities;
using MediatR;
using MyNotes.Domain.Queries.Responses;
using MyNotes.Domain.Queries.Requests;
using MyNotes.Domain.Commands.Requests;
using MyNotes.Domain.Queries.Request;
using MyNotes.Domain.Commands.Responses;

namespace MyNotes.Controller;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase{

  private readonly IMediator _mediator;
  
  public UserController(IMediator mediator)
    => this._mediator = mediator;

  [HttpGet("{id}")]
  public async Task<User>getUser([FromRoute]string id)
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


  [HttpGet("{id}/note")]
  public async Task<IEnumerable<GetNotesResponse>> GetNotes(
      [FromRoute] string id)
    => await _mediator.Send(new GetNotesRequest(id));
  
  [HttpGet("{id}/note/{noteId}")]
  public async Task<Note> GetNotes(
      [FromRoute] string id,
      [FromRoute] string noteId)
    => await _mediator.Send(new GetNoteRequest(id,noteId));


  [HttpPost("{id}/notes")]
  public async Task<Note> newNote(
      [FromRoute] string id,
      [FromBody] CreateNoteRequestText request)
    => await _mediator.Send(new CreateNoteRequest(id, request.title));

  /*
  [HttpGet("{id}/notes/{noteId}")]
  public async Task GetNote(
      [FromRoute] string id,
      [FromRoute] string noteId
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
