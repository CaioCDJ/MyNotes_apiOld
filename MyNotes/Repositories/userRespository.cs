using MyNotes.Entities;
using Microsoft.Data.Sqlite;
using Dapper;
using MyNotes.Domain.Queries.Requests;

namespace MyNotes.Repository;

public class UserRepository{

  private readonly DataContext _dataContext;
  private readonly SqliteConnection _conn;

  public UserRepository(DataContext dataContext){
    _dataContext = dataContext;
    _conn = new SqliteConnection(_dataContext.Database.GetConnectionString());
  }
  
  public async Task<User?> GetById(string id)
    => await _conn.QueryFirstAsync<User>(
      sql: $"SELECT * FROM Users WHERE Id = '{id}';");

  public async Task<User?> GetLogin(LoginRequest loginRequest)
    => await _conn.QuerySingleOrDefaultAsync<User>(
      "SELECT * FROM Users WHERE email = @email AND password = @password;", loginRequest);
  
  public async Task Add(User user){

    _dataContext.Users.Add(user);
    await _dataContext.SaveChangesAsync();  
  }
  
  public async Task<User?> Update(User user){
    _dataContext.Users.Update(user);
    await _dataContext.SaveChangesAsync();
    return await GetById(user.Id.ToString());
  }
  
  public async Task remove(string id){
    var user = await _dataContext.Users.SingleOrDefaultAsync(x=> x.Id == id);
    if(!string.IsNullOrWhiteSpace(user.Id.ToString()))
      _dataContext.Users.Remove(user);

    await _dataContext.SaveChangesAsync();
  }
}

