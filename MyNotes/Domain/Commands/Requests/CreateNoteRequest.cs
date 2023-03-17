using MyNotes.Entities;
using MediatR;

public record CreateNoteRequest(
  Guid id,
  string title,
  string text
) : IRequest<Note>;
