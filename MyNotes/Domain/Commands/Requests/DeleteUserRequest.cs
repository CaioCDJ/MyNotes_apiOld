using MediatR;
using MyNotes.Commands.Responses;

namespace MyNotes.Commands.Requests;

public record DeleteUserRequest(string id) : IRequest<string>;
