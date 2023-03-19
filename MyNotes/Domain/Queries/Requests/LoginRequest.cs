using MyNotes.Domain.Queries.Responses;
using MediatR;

namespace MyNotes.Domain.Queries.Requests;

public record LoginRequest(string email, string password): IRequest<LoginResponse>;
