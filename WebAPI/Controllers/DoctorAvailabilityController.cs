using Application.Features.DoctorAvailabilities.Commands.Create;
using Application.Features.DoctorAvailabilities.Commands.Delete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAvailabilityController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateDoctorAvailabilityCommand command)
        {
            CreateDoctorAvailabilityResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteDoctorAvailabilityCommand command = new() { Id = id };
            DeleteDoctorAvailabilityResponse response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
