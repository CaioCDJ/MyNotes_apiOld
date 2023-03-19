using MediatR;
using MyNotes.Domain.Commands.Responses;

namespace MyNotes.Domain.Commands.Requests;

public record CreateUserRequest(
    string name,
    string email,
    string password
) : IRequest<CreateUserResponse> ;
