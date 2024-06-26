using Application.Features.OperationClaims.Commands.Create;
using Application.Features.OperationClaims.Commands.Delete;
using Application.Features.OperationClaims.Commands.SoftDelete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand command)
        {
            CreateOperationClaimResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteOperationClaimCommand command = new() { Id = id };
            DeleteOperationClaimResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("soft-delete/{id}")]
        public async Task<IActionResult> SoftDelete([FromRoute] int id)
        {
            SoftDeleteOperationClaimCommand command = new() { Id = id };
            SoftDeleteOperationClaimResponse response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
