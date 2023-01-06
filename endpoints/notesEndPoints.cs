using Microsoft.AspNetCore.Mvc;
using MyNotes_api.controllers;

namespace MyNotes_api.Endpoints;

public static class NotesEndpoints{

  public static void MapNotes( this WebApplication app){
  

   app.MapGet("/user/{id}/notes", NotesController.getNotes);
   app.MapGet("/user/{id}/notes/{noteId}", NotesController.getNote);
   app.MapPost("/user/{id}/notes", NotesController.newNote);
   app.MapDelete("/user/{id}/notes/{noteApi}", NotesController.remove);
  }



}
