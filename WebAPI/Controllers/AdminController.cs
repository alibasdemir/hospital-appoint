using Application.Features.Admins.Commands.Create;
using Application.Features.Admins.Commands.Delete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateAdminCommand command)
        {
            CreateAdminResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteAdminCommand command = new() { Id = id };
            await _mediator.Send(command);
            return Ok("Deletion successful!");
        }
    }
}
