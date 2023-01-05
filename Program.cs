using MyNotes_api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(); 
app.UseAuthorization();
app.UseAuthentication();

app.MapUserEndpoints();
app.MapGet("/", () => "Hello World!");

app.Run();
