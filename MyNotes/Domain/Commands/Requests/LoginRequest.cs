using MyNotes.Commands.Responses;
using MediatR;

namespace MyNotes.Commands.Requests;

public record LoginRequest(string email, string password): IRequest<LoginResponse>;
