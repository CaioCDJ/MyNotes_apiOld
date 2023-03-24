using Microsoft.AspNetCore.Mvc;
using MyNotes.Entities;
using MediatR;
using MyNotes.Domain.Queries.Responses;
using MyNotes.Domain.Queries.Requests;
using MyNotes.Domain.Commands.Requests;
using MyNotes.Domain.Queries.Request;
using MyNotes.Domain.Commands.Responses;
using Microsoft.AspNetCore.Authorization;

namespace MyNotes.Controller;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase{

  private readonly IMediator _mediator;
  
  public UserController(IMediator mediator)
    => this._mediator = mediator;

  [HttpGet("{id}")]
  [Authorize]
  public async Task<IActionResult>getUser([FromRoute]string id)
    => await SendRequest(new GetUserByIdRequest(id));


  [HttpPost("login")]
  [AllowAnonymous]
  public async Task<IActionResult> Login(
    [FromBody] LoginRequest loginRequest)
    => await SendRequest(loginRequest);
 
  [HttpPost]
  [AllowAnonymous]
  public async Task<IActionResult>newUser(
      [FromBody] CreateUserRequest createUserRequest)
    => await SendRequest(createUserRequest);

  [HttpPatch("{id}/password")]
  [Authorize]
  public async Task<IActionResult>updatePassword(
      [FromRoute]Guid id,
      [FromBody]PasswordRequest request) 
    => await SendRequest(new ChangePasswordRequest(id, request.password, request.newPassword));
  
  [HttpDelete("{id}")]
  [Authorize]
  public async Task<IActionResult> deleteUser([FromRoute]Guid id)
    => await SendRequest(new DeleteUserRequest(id));

  // -- Notes --

  // list - create - update - delete

  [HttpGet("{id}/note")]
  [Authorize]
  public async Task<IActionResult> GetNotes(
      [FromRoute] string id)
    => await SendRequest(new GetNotesRequest(id));
  
  [HttpGet("{id}/note/{noteId}")]
  [Authorize]
  public async Task<IActionResult> GetNotes(
      [FromRoute] string id,
      [FromRoute] string noteId)
    => await SendRequest(new GetNoteRequest(id,noteId));


  [HttpPost("{id}/notes")]
  [Authorize]
  public async Task<IActionResult> newNote(
      [FromRoute] string id,
      [FromBody] CreateNoteRequestText request)
    => await SendRequest(new CreateNoteRequest(id, request.title));

  [HttpDelete("{id}/notes/{noteId}")]
  [Authorize]
  public async Task<IActionResult> deleteNote(
      [FromRoute] string id,
      [FromRoute] string noteId)
    => await SendRequest(new DeleteNoteRequest(id,noteId));
  
  [HttpGet("{id}/notes/{noteId}")]
  [Authorize]
  public async Task GetNote(
      [FromRoute] string id,
      [FromRoute] string noteId,
      [FromBody] NoteUpdateRequestBody request)
    => await SendRequest(new NoteUpdateRequest(id,request.title, request.text, noteId));

  
  private async Task<IActionResult>SendRequest(Object request){
    try{
      var obj = await _mediator.Send(request);
      
      return (obj is not null)
        ? Ok(obj)
        : NotFound();
    }
    catch (Exception e){
      return BadRequest(e.Message);
    }
  }
}
