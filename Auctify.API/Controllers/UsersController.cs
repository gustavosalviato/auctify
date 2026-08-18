using Auctify.API.UseCases.Users.Create;
using Auctify.Communication.Requests;
using Auctify.Communication.Responses;
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
        var useCase = new CreateUserUseCase();

        var response = useCase.Execute(request);

        return Created(string.Empty, response);
    }
}