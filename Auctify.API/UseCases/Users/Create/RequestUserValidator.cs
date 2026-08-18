using Auctify.Communication.Requests;
using FluentValidation;

namespace Auctify.API.UseCases.Users.Create;

public class RequestUserValidator : AbstractValidator<RequestUserJson>
{
   public RequestUserValidator()
   {
      RuleFor(user => user.Name).NotEmpty().WithMessage("Name could not be empty.");
      RuleFor(user => user.Email).EmailAddress().WithMessage("Invalid email address.");
   }
}