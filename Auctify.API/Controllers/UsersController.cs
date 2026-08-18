using Auctify.API.Entities;
using Auctify.API.UseCases.Users.Create;
using Auctify.Communication.Requests;
using Auctify.Communication.Responses;
using Auctify.Exceptions.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;

namespace Auctify.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : Controller
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestUserJson request)
    {
        try
        {
            var useCase = new CreateUserUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }
        catch (ExceptionBase ex)
        {
            var errors = ex.GetErrors();
            
            return BadRequest(new ResponseErrorMessagesJson(errors));
        }
    }
}