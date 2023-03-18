using MyNotes.Entities;
using MediatR;

public record CreateNoteRequest(
  string id,
  string title,
  string text
) : IRequest<Note>;
