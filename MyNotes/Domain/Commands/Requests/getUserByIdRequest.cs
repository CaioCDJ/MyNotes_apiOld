using MyNotes.Entities;
using MediatR;

namespace MyNotes.Commands.Requests;

public record GetUserByIdRequest(string id) : IRequest<User>;
