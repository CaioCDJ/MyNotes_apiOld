using MyNotes.Domain.Commands.Requests;
using FluentValidation;

namespace MyNotes.Validations;

public class CreateUserValidation: AbstractValidator<CreateUserRequest>{

  public CreateUserValidation(){
    
    RuleFor(x=> x.name).NotEmpty().NotEmpty().MinimumLength(3);
    RuleFor(x=> x.password).NotEmpty().NotNull().MinimumLength(6);
    RuleFor(x=> x.email).EmailAddress().NotNull().NotEmpty();
  }
}
