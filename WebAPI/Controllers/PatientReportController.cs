using Application.Features.PatientReports.Commands.Create;
using Application.Features.PatientReports.Commands.Delete;
using Application.Features.PatientReports.Commands.SoftDelete;
using Application.Features.PatientReports.Commands.Update;
using Application.Features.PatientReports.Queries.GetById;
using Application.Features.PatientReports.Queries.GetList;
using Core.Requests;
using Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientReportController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreatePatientReportCommand command)
        {
            CreatePatientReportResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeletePatientReportCommand command = new() { Id = id };
            DeletePatientReportResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("soft-delete/{id}")]
        public async Task<IActionResult> SoftDelete([FromRoute] int id)
        {
            SoftDeletePatientReportCommand command = new() { Id = id };
            SoftDeletePatientReportResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePatientReportCommand command)
        {
            UpdatePatientReportResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            GetByIdPatientReportQuery query = new() { Id = id };
            GetByIdPatientReportResponse response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            GetListPatientReportQuery query = new() { PageRequest = pageRequest };
            GetListResponse<GetListPatientReportResponse> response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
