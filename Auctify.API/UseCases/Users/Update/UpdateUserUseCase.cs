using Auctify.API.Contracts;
using Auctify.Communication.Requests;
using Auctify.Communication.Responses.User;
using Auctify.Exceptions.ExceptionsBase;

namespace Auctify.API.UseCases.Users.Update;

public class UpdateUserUseCase
{
    private readonly IUserRepository _userRepository;

    public UpdateUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void Execute(Guid userId, RequestUpdateUserJson request)
    {
        Validate(request);

        var user = _userRepository.FindById(userId);

        if (user is null)
            throw new NotFoundErrorException("User does not exist.");

        user.Name = request.Name;

        _userRepository.Update(user);
    }

    private void Validate(RequestUpdateUserJson request)
    {
        var validator = new RequestUpdateUserValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errors = result.Errors.Select(error => error.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errors);
        }
    }
}