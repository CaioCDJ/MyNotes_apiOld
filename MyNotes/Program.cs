global using Microsoft.EntityFrameworkCore;
global using MyNotes.Data;
using MyNotes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<GloblaExceptioinMiddleware>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddDbContext<DataContext>(
  options => options.UseSqlite("DataSource=app.db;Cache=Shared")
);

var app = builder.Build();

if(app.Environment.IsDevelopment()){
  app.UseSwagger();
   app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<GloblaExceptioinMiddleware>();

/* -- middleware basico --
app.Use(async(context,next)=>{
  try{
    await next(context);
    }
    catch(Exception e){
     context.Response.StatusCode = 500;
    }
});
*/

app.Run();
