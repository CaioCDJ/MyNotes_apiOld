using MyNotes.Entities;
using MediatR;

namespace MyNotes.Domain.Queries.Requests;

public record GetUserByIdRequest(string id) : IRequest<User>;
