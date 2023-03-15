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

  private readonly ISender _sender;
  
  public UserController(ISender _sender)
    => this._sender = _sender;

  // Rota test
  //[HttpGet]
  //public async Task<ActionResult>getUsers(){return Ok(users);}

  [HttpGet("{id}")]
  public async Task<ActionResult>getUser([FromRoute]string id){
    return Ok();
  }

  [HttpPost("login")]
  public async Task<ActionResult> Login(
    [FromBody] LoginRequest loginRequest
  ){

    try{
      var login = await _sender.Send(loginRequest);
      if(login is not null)
        return Ok(login);
      else
        return BadRequest();
    }
    catch (Exception e){
      return BadRequest(e.Message);    
    }
  }
 
  [HttpPost]
  public async Task<ActionResult>newUser(
      [FromServices] IMediator mediatr,
      [FromBody] CreateUserRequest createUserRequest){
 
    try{
         
      var response = await mediatr.Send(createUserRequest);

      if(response is not null)
        return Ok(response);
      else
        return BadRequest();
    }
    catch (System.Exception e){
      return BadRequest(e.Message);
    }
  }

  // -- Notes --

  // list - create - update - delete

}
