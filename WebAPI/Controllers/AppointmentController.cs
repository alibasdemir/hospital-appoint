using Application.Features.Appointments.Commands.Create;
using Application.Features.Appointments.Commands.Delete;
using Application.Features.Appointments.Commands.SoftDelete;
using Application.Features.Appointments.Commands.Update;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateAppointmentCommand command)
        {
            CreateAppointmentResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteAppointmentCommand command = new() { Id = id };
            await _mediator.Send(command);
            DeleteAppointmentResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("soft-delete/{id}")]
        public async Task<IActionResult> SoftDelete([FromRoute] int id)
        {
            SoftDeleteAppointmentCommand command = new() { Id = id };
            SoftDeleteAppointmentResponse response = await _mediator.Send(command);
            return Ok(response);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAppointmentCommand command)
        {
            UpdateAppointmentResponse response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}