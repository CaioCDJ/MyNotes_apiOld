global using Microsoft.EntityFrameworkCore;
global using MyNotes.Data;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddDbContext<DataContext>(
  options => options.UseInMemoryDatabase("MyNotes")
);

var app = builder.Build();

if(app.Environment.IsDevelopment()){
  app.UseSwagger();
   app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
