using MyNotes.Domain.Commands.Requests;
using FluentValidation;

namespace MyNotes.Validations;

public class ChangePasswordValidation : AbstractValidator<ChangePasswordRequest>{

  public ChangePasswordValidation(){

    RuleFor(x=> x.id).NotNull().NotEmpty();
    RuleFor(x=> x.password ).NotNull().NotEmpty().NotEqual(x=> x.newPassword);
    RuleFor(x=> x.newPassword).NotNull().NotEmpty();
  
  }
}
