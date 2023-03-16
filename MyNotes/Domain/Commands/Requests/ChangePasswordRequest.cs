using MediatR;

namespace MyNotes.Commands.Requests;

public record ChangePasswordRequest(string id, string password, string newPassword) : IRequest<string>;

public record PasswordRequest(string password, string newPassword);

