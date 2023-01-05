using Microsoft.AspNetCore.Mvc;

namespace MyNotes_api.Endpoints;

public static class userEndpoints{

  public static void MapUserEndpoints( this WebApplication app){

    app.MapGet("/oliverTheDog",async()=>{
      return Results.Ok("oliver is the one and only dog");
    });
    
   app.MapGet("/user/{id}", async ([FromRouteAttribute] string id)=>{
       return Results.Ok(id);
    }) ;
  }

}
