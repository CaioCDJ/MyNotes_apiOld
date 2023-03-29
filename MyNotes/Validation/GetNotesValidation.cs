using MyNotes.Domain.Queries.Requests;
using FluentValidation;

namespace MyNotes.Validations;

public class GetNotesValidation : AbstractValidator<GetNotesRequest>{

  public GetNotesValidation(){
    RuleFor(x=> x.userId).MinimumLength(36).NotEmpty().NotNull();
  }
}
