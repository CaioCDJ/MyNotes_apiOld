using Microsoft.AspNetCore.Mvc;
using MyNotes.Data;
using MyNotes.Commands.Handlers;
using MyNotes.Commands.Responses;
using MyNotes.Commands.Requests;
using MediatR;

namespace MyNotes.Controller;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase{

  //private readonly ISender _sender;
  
  private readonly DataContext _context;

  /*
  public UserController(ISender sender){
    this._sender = sender;
  }
  */

  [HttpGet("{id}")]
  public async Task<ActionResult>getUser([FromRoute]string id){
    return Ok();
  }

  [HttpPost("login")]
  public async Task<ActionResult> Login(
    [FromServices] IMediator handler,
    [FromBody] LoginRequest loginRequest
  ){
    System.Console.WriteLine("Oliber the boxer");
    var login = await handler.Send(loginRequest);

    if(login is not null)
      return Ok(login);
    else
      return BadRequest();
  }
 
  [HttpPost]
  public async Task<ActionResult>newUser([FromBody] CreateUserRequest createUserRequest){
    return Ok("oliver is a dog");
  }


  // -- Notes --

  // list - create - update - delete

}
