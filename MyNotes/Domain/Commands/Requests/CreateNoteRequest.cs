using MyNotes.Entities;
using MediatR;

namespace MyNotes.Domain.Commands.Requests;

public record CreateNoteRequestText(string title);

public record CreateNoteRequest(
  string userId,
  string title
) : IRequest<Note>;
