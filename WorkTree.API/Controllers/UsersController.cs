using WorkTree.Communication.Requests;
using WorkTree.Communication.Responses;
using WorkTree.Communication.Responses.User;
using Microsoft.AspNetCore.Mvc;
using WorkTree.API.UseCases.Users.Create;
using WorkTree.API.UseCases.Users.Delete;
using WorkTree.API.UseCases.Users.Update;

namespace WorkTree.API.Controllers;

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


    [HttpDelete]
    [Route("{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] Guid userId, [FromServices] DeleteUserUseCase useCase)
    {
        useCase.Execute(userId);

        return Ok();
    }
}