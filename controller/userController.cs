using Microsoft.AspNetCore.Mvc;

namespace MyNotes_api.controllers;

public class UserController{
  
  // -- Users --
  public static async Task<IResult> getUser(){
    return Results.Ok();
  }

  public static async Task<IResult> newUser(){
    return Results.Ok();
  }

  public static async Task<IResult> updateUser(){
    return Results.Ok();
  }
  
  public static async Task<IResult> deleteUser(){
    return Results.Ok();
  }
}
