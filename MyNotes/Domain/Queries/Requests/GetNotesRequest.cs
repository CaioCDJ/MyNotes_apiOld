using MediatR;
using MyNotes.Domain.Queries.Responses;

namespace MyNotes.Domain.Queries.Requests;

public record GetNotesRequest(string userId) : IRequest<IEnumerable<GetNotesResponse>>;
