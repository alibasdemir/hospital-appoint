using Application.Features.Patients.Commands.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreatePatientCommand command)
        {
            CreatePatientResponse response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
