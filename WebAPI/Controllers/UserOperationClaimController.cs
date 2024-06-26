using Application.Features.UserOperationClaims.Commands.Create;
using Application.Features.UserOperationClaims.Commands.Delete;
using Application.Features.UserOperationClaims.Commands.SoftDelete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand command)
        {
            CreateUserOperationClaimResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteUserOperationClaimCommand command = new() { Id = id };
            DeleteUserOperationClaimResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("soft-delete/{id}")]
        public async Task<IActionResult> SoftDelete([FromRoute] int id)
        {
            SoftDeleteUserOperationClaimCommand command = new() { Id = id };
            SoftDeleteUserOperationClaimResponse response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
