using Application.Features.OperationClaims.Commands.Create;
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
    }
}
