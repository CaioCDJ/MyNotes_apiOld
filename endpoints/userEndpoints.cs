using Microsoft.AspNetCore.Mvc;
using MyNotes_api.controllers;

namespace MyNotes_api.Endpoints;

public static class userEndpoints{

  public static void MapUserEndpoints( this WebApplication app){
  
    app.MapPost("/login", UserController.getUser);
    app.MapGet("/user/{id}", UserController.getUser);
    app.MapPost("/user", UserController.newUser);
    app.MapPut("/user/{id}", UserController.updateUser);
    app.MapDelete("/user/{id}", UserController.deleteUser);
  }
}
