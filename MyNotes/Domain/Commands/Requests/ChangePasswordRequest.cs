using MediatR;

namespace MyNotes.Domain.Commands.Requests;

public record ChangePasswordRequest(Guid id, string password, string newPassword) : IRequest<string>;

public record PasswordRequest(string password, string newPassword);

