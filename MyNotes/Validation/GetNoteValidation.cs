using MyNotes.Domain.Queries.Requests;
using FluentValidation;

namespace MyNotes.Validations;

public class GetNoteValidation : AbstractValidator<GetNoteRequest>{

  public GetNoteValidation(){
    RuleFor(x=> x.userId).NotNull().NotEmpty().MinimumLength(36);
    RuleFor(x=> x.id).NotEmpty().NotNull().MinimumLength(36);
  }
}
