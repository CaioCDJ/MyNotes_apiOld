using MyNotes.Entities;
using MediatR;

namespace MyNotes.Domain.Commands.Requests;

public record NoteUpdateRequestBody(
    string title,
    string text
    );

public record NoteUpdateRequest(
    string id,
    string title,
    string text,
    string userId
    ) : IRequest<Note>;
