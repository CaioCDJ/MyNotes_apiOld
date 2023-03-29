using MyNotes.Domain.Commands.Requests;
using FluentValidation;

namespace MyNotes.Validations;

public class NoteUpdateValidationn : AbstractValidator<NoteUpdateRequest>{

  public NoteUpdateValidationn(){
    RuleFor(x=> x.id).NotNull().NotEmpty().MinimumLength(36);
    RuleFor(x=> x.userId).NotEmpty().NotNull().MinimumLength(36);
    RuleFor(x=>x.title).NotNull();
    RuleFor(x=> x.text).NotNull();
  }
}
