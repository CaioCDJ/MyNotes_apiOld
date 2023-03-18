using MyNotes.Entities;
using MyNotes.Commands.Responses;
using MyNotes.Commands.Requests;
using Microsoft.Data.Sqlite;
using Dapper;

namespace MyNotes.Repository;

public class NotesRepository{

  private readonly DataContext _dataContext;
  private readonly SqliteConnection _conn;

  public NotesRepository(DataContext dataContext){
    _dataContext = dataContext;
    _conn = new SqliteConnection(dataContext.Database.GetConnectionString());
  }

  public async Task<Note> GetNoteById(string id)
    => await _conn.QueryFirstAsync<Note>(
        sql: $"SELECT * FROM Notes WHERE Id = {id}");

  public async Task GetNotes(string userID)
    => await _conn.QueryAsync(
        sql:@"SELECT Id, title, updatedAt FROM Notes WHERE userId = '@userID';",
        userID
        );

  public async Task Add(Note note){
    await _dataContext.Notes.AddAsync(note);
    await _dataContext.SaveChangesAsync();
  }

  public async Task<Note>Update(Note note){
    
    _dataContext.Notes.Update(note);
    await _dataContext.SaveChangesAsync();
    
    return await GetNoteById(note.Id);
  }

  public async Task delete(Note note){
    _dataContext.Notes.Remove(note);
    await _dataContext.SaveChangesAsync();
  }
}
