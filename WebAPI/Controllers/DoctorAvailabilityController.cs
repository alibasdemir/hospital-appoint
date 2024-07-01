using Application.Features.DoctorAvailabilities.Commands.Create;
using Application.Features.DoctorAvailabilities.Commands.Delete;
using Application.Features.DoctorAvailabilities.Commands.SoftDelete;
using Application.Features.DoctorAvailabilities.Commands.Update;
using Application.Features.DoctorAvailabilities.Queries.GetById;
using Application.Features.DoctorAvailabilities.Queries.GetList;
using Core.Requests;
using Core.Responses;
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

        [HttpDelete("soft-delete/{id}")]
        public async Task<IActionResult> SoftDelete([FromRoute] int id)
        {
            SoftDeleteDoctorAvailabilityCommand command = new() { Id = id };
            SoftDeleteDoctorAvailabilityResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            GetByIdDoctorAvailabilityQuery query = new() { Id = id };
            GetByIdDoctorAvailabilityResponse response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            GetListDoctorAvailabilityQuery query = new() { PageRequest = pageRequest };
            GetListResponse<GetListDoctorAvailabilityResponse> response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDoctorAvailabilityCommand command)
        {
            UpdateDoctorAvailabilityResponse response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
