using MediatR;
using MyNotes.Entities;

namespace MyNotes.Domain.Queries.Requests;

public record GetNoteRequest(string id, string userId) : IRequest<Note>;
