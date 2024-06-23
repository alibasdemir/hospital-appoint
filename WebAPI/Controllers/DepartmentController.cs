using Application.Features.Departments.Commands.Create;
using Application.Features.Departments.Commands.Delete;
using Application.Features.Departments.Commands.SoftDelete;
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
            await _mediator.Send(command);
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
    }
}