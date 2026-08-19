using Auctify.API.UseCases.Users.Create;
using Auctify.API.UseCases.Users.Update;
using Auctify.Communication.Requests;
using Auctify.Communication.Responses;
using Auctify.Communication.Responses.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace Auctify.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : Controller
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status409Conflict)]
    public IActionResult Register([FromBody] RequestUserJson request, [FromServices] CreateUserUseCase useCase)
    {
        var response = useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpPut]
    [Route("{userId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    public IActionResult Update([FromRoute] Guid userId, [FromBody] RequestUpdateUserJson request,
        [FromServices] UpdateUserUseCase useCase)
    {
        useCase.Execute(userId, request);

        return NoContent();
    }

    public IActionResult Delete()
    {
        return Ok();
    }
}