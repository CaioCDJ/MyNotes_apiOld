using MyNotes.Domain.Queries.Requests;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace MyNotes.Domain.Commands.Requests;

public record DeleteNoteRequest(string userId,string id) : IRequest<string> ;
