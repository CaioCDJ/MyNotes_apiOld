
namespace MyNotes.Commands.Responses;

public record GetNotesResponse(
    Guid id, 
    string title,
    DateTime createdAt,
    DateTime updatedAt);
