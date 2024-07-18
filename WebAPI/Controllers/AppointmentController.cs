using Application.Features.Appointments.Commands.Create;
using Application.Features.Appointments.Commands.Delete;
using Application.Features.Appointments.Commands.SoftDelete;
using Application.Features.Appointments.Commands.Update;
using Application.Features.Appointments.Queries.GetByDoctorAndDate;
using Application.Features.Appointments.Queries.GetByDoctorAndWeek;
using Application.Features.Appointments.Queries.GetById;
using Application.Features.Appointments.Queries.GetByPatient;
using Application.Features.Appointments.Queries.GetList;
using Core.Requests;
using Core.Responses;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            GetByIdAppointmentQuery query = new() { Id = id };
            GetByIdAppointmentResponse response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            GetListAppointmentQuery query = new() { PageRequest = pageRequest };
            GetListResponse<GetListAppointmentResponse> response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("by-doctor-and-week")]
        public async Task<IActionResult> GetByDoctorAndWeek([FromQuery] PageRequest pageRequest, [FromQuery] int doctorId, [FromQuery] DateTime date)
        {
            var query = new GetAppointmentsByDoctorAndWeekQuery
            {
                PageRequest = pageRequest,
                DoctorId = doctorId,
                Date = date
            };
            GetListResponse<GetAppointmentsByDoctorAndWeekResponse> response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("by-patient")]
        public async Task<IActionResult> GetByPatient([FromQuery] PageRequest pageRequest, [FromQuery] int patientId)
        {
            GetAppointmentsByPatientQuery query = new()
            {
                PageRequest = pageRequest,
                PatientId = patientId
            };

            GetListResponse<GetAppointmentsByPatientResponse> response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("by-doctor-and-date")]
        public async Task<IActionResult> GetByDoctorAndDate([FromQuery] PageRequest pageRequest, [FromQuery] int doctorId, [FromQuery] DateTime date)
        {
            GetAppointmentsByDoctorAndDateQuery query = new()
            {
                PageRequest = pageRequest,
                DoctorId = doctorId,
                Date = date
            };

            GetListResponse<GetAppointmentsByDoctorAndDateResponse> response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}