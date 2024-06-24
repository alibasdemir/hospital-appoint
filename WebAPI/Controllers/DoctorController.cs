using Application.Features.Doctors.Commands.Create;
using Application.Features.Doctors.Commands.Delete;
using Application.Features.Doctors.Commands.Update;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateDoctorCommand command)
        {
            CreateDoctorResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteDoctorCommand command = new() { Id = id };
            DeleteDoctorResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDoctorCommand command)
        {
            UpdateDoctorResponse response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
