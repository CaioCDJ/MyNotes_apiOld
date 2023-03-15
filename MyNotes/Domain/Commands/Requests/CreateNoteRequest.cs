using MediatR;

public record CreateNoteRequest(
    string title,
    string text
);
