using MediatR;
using MyNotes.Domain.Commands.Responses;

namespace MyNotes.Domain.Commands.Requests;

public record DeleteUserRequest(Guid id) : IRequest<string>;
