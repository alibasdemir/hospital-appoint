using Application.Features.Doctors.Commands.Create;
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
    }
}
