using MyNotes.Entities;
using MyNotes.Commands.Responses;
using MyNotes.Commands.Requests;

namespace MyNotes.Repository;

public class UserRepository{

  private readonly DataContext _dataContext;

  public UserRepository(DataContext _dataContext) 
    => this._dataContext = _dataContext;

  public async Task<User?> GetById(Guid id)
    => await _dataContext.Users.SingleOrDefaultAsync(x => x.Id == id);
  
  public async Task<User?> GetLogin(LoginRequest loginRequest)
    => await _dataContext.Users.SingleOrDefaultAsync(
        x => x.email == loginRequest.email && x.password == loginRequest.password);
  
  public async Task Add(User user){

    _dataContext.Users.Add(user);

    await _dataContext.SaveChangesAsync();  
  }
  
  public async Task<User?> Update(User user){
    _dataContext.Users.Update(user);
    await _dataContext.SaveChangesAsync();
    return await GetById(user.Id);
  }
  
  public async Task remove(Guid id){
    var user = await _dataContext.Users.SingleOrDefaultAsync(x=> x.Id == id);
    if(!string.IsNullOrWhiteSpace(user.Id.ToString()))
      _dataContext.Users.Remove(user);

    await _dataContext.SaveChangesAsync();
  }
}

