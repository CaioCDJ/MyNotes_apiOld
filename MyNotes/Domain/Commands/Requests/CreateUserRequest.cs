using MediatR;
using MyNotes.Commands.Responses;

namespace MyNotes.Commands.Requests;

public record CreateUserRequest(
    string name,
    string email,
    string password
) : IRequest<CreateUserResponse> ;
