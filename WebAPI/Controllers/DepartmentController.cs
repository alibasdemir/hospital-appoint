using Application.Features.Departments.Commands.Create;
using Application.Features.Departments.Commands.Delete;
using Application.Features.Departments.Commands.SoftDelete;
using Application.Features.Departments.Commands.Update;
using Application.Features.Departments.Queries.GetById;
using Application.Features.Departments.Queries.GetList;
using Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateDepartmentCommand command)
        {
            CreateDepartmentResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteDepartmentCommand command = new() { Id = id };
            DeleteDepartmentResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("soft-delete/{id}")]
        public async Task<IActionResult> SoftDelete([FromRoute] int id)
        {
            SoftDeleteDepartmentCommand command = new() { Id = id };
            SoftDeleteDepartmentResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            GetByIdDepartmentQuery query = new() { Id = id };
            GetByIdDepartmentResponse response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetListDepartmentQuery query)
        {
            GetListResponse<GetListDepartmentResponse> response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDepartmentCommand command)
        {
            UpdateDepartmentResponse response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}