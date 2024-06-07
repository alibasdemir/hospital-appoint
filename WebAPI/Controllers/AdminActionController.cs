using Application.Features.AdminActions.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminActionController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CreateAdminActionCommand command)
        {
            CreateAdminActionResponse response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
