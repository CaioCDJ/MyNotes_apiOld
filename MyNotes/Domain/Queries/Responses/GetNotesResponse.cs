
namespace MyNotes.Domain.Queries.Responses;

public record GetNotesResponse(
    string Id, 
    string title,
    string updatedAt);
