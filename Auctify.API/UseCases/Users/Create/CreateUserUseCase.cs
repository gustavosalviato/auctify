using Auctify.API.Entities;
using Auctify.Communication.Requests;
using Auctify.Communication.Responses;
using Auctify.Exceptions.ExceptionsBase;

namespace Auctify.API.UseCases.Users.Create;

public class CreateUserUseCase
{
   public ResponseUserJson Execute(RequestUserJson request)
   {
      Validate(request);
      
      var user = new User
      {
         Name = request.Name,
         Email = request.Email,
      }; 

      return new ResponseUserJson
      {
         Name = user.Name,
         Email = user.Email,
      };
   }

   private void Validate(RequestUserJson request)
   {
      var validator = new RequestUserValidator();

      var result = validator.Validate(request);

      if (!result.IsValid)
      {
         var errors = result.Errors.Select(error => error.ErrorMessage).ToList();
         
         throw new ErrorOnValidationException(errors);
      }

   }
}