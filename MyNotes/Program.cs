global using Microsoft.EntityFrameworkCore;
global using MyNotes.Data;
using MyNotes;
using MyNotes.Security;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<GloblaExceptioinMiddleware>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<TokenService>();

builder.Services.AddAuthentication("Bearer")
  .AddJwtBearer(x=>{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters{
      ValidateIssuerSigningKey = true,
    };
  });

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

app.UseAuthentication();

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
