using MediatR;
using MyNotes.Domain.Commands.Responses;

namespace MyNotes.Domain.Queries.Request;

public record DeleteUserRequest(Guid id) : IRequest<string>;
