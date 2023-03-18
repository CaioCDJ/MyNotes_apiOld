using MediatR;
using MyNotes.Commands.Responses;

namespace MyNotes.Commands.Requests;

public record DeleteUserRequest(Guid id) : IRequest<string>;
