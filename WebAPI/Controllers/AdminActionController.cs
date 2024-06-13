using Application.Features.AdminActions.Commands.Create;
using Application.Features.AdminActions.Commands.Delete;
using Application.Features.AdminActions.Commands.Update;
using Application.Features.AdminActions.Queries.GetById;
using Application.Features.AdminActions.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminActionController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateAdminActionCommand command)
        {
            CreateAdminActionResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteAdminActionCommand command = new() { Id = id };
            await _mediator.Send(command);
            return Ok("Deletion successful!");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAdminActionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListAdminActionQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            GetByIdAdminActionQuery query = new() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
