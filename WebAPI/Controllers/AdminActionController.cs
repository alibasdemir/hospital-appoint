using Application.Features.AdminActions.Commands.Create;
using Application.Features.AdminActions.Commands.Delete;
using Application.Features.Users.Commands.Delete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminActionController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateAdminActionCommand command)
        {
            CreateAdminActionResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteAdminActionCommand command = new() { Id = id };
            await _mediator.Send(command);
            return Ok("Deletion successful!");
        }

    }
}
