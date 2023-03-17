using MyNotes.Entities;
using MediatR;

namespace MyNotes.Commands.Requests;

public record GetUserByIdRequest(Guid id) : IRequest<User>;
