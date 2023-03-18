using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace MyNotes;

public class GloblaExceptioinMiddleware : IMiddleware{
 
  public async Task InvokeAsync(HttpContext context, RequestDelegate next){
    try{       
      await next(context);
    }
    catch (Exception e){
      Console.WriteLine(e.Message);
      context.Response.StatusCode = 500;
    
      ProblemDetails prolem = new(){
        Status = 500,
        Type = "Server Error",
        Title = "Server Error",
        Detail = e.Message,
      };

      string json = JsonSerializer.Serialize(prolem);

      context.Response.ContentType = "application/json";
    
      await context.Response.WriteAsync(json);
    }
  }
}
