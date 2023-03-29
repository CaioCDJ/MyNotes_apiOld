using MyNotes.Domain.Queries.Requests;
using FluentValidation;

namespace MyNotes.Validations;

public class LoginValidation : AbstractValidator<LoginRequest>{

  public LoginValidation(){
    RuleFor(x=> x.email).EmailAddress().NotNull().NotEmpty();
    RuleFor(x=>x.password).NotEmpty().NotNull();
  }
}
