using Auctify.Communication.Requests;
using Auctify.Communication.Responses.User;
using FluentValidation;

namespace Auctify.API.UseCases.Users.Update;

public class RequestUpdateUserValidator : AbstractValidator<RequestUpdateUserJson>
{
    public RequestUpdateUserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage("Name could not be empty.");
    }
}