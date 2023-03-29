using MyNotes.Domain.Commands.Requests;
using FluentValidation;

namespace MyNotes.Validations;

public class CreateNoteValidation : AbstractValidator<CreateNoteRequest>{

  public CreateNoteValidation(){
    
    RuleFor(x=> x.title).NotEmpty().NotNull();
    RuleFor(x=> x.userId).NotEmpty().NotNull().MinimumLength(36).MaximumLength(36);
  }
}
