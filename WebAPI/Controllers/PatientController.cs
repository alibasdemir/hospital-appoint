using Application.Features.Patients.Commands.Create;
using Application.Features.Patients.Commands.Delete;
using Application.Features.Patients.Commands.SoftDelete;
using Application.Features.Patients.Commands.Update;
using Application.Features.Patients.Queries.GetById;
using Application.Features.Patients.Queries.GetList;
using Core.Requests;
using Core.Responses;
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeletePatientCommand command = new() { Id = id };
            DeletePatientResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("soft-delete/{id}")]
        public async Task<IActionResult> SoftDelete([FromRoute] int id)
        {
            SoftDeletePatientCommand command = new() { Id = id };
            SoftDeletePatientResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePatientCommand command)
        {
            UpdatePatientResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            GetByIdPatientQuery query = new() { Id = id };
            GetByIdPatientResponse response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            GetListPatientQuery query = new() { PageRequest = pageRequest };
            GetListResponse<GetListPatientResponse> response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
