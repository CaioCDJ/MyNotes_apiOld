using MediatR;

namespace MyNotes.Commands.Requests;

public record GetNotesRequest(Guid userId) : IRequest<GetNotesRequest>;
