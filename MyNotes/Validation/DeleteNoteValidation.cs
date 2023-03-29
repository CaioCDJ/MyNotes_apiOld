using MyNotes.Domain.Commands.Requests;
using FluentValidation;

namespace MyNotes.Validations;

public class DeleteNoteValidation : AbstractValidator<DeleteNoteRequest>{

  public DeleteNoteValidation(){
    
    RuleFor(x=> x.userId).NotEmpty().NotNull().MinimumLength(36);
    RuleFor(x=> x.id).NotNull().NotEmpty().MinimumLength(36);
  }
}
