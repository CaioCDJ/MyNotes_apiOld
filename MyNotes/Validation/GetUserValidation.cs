using MyNotes.Domain.Queries.Requests;
using FluentValidation;

namespace MyNotes.Validations;

public class GetUserValidation: AbstractValidator<GetUserByIdRequest>{

  public GetUserValidation(){
    RuleFor(x => x.id).NotEmpty().NotNull();
  }
}
