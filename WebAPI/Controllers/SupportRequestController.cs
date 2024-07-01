using Application.Features.SupportRequests.Commands.Create;
using Application.Features.SupportRequests.Commands.Delete;
using Application.Features.SupportRequests.Commands.SoftDelete;
using Application.Features.SupportRequests.Commands.Update;
using Application.Features.SupportRequests.Queries.GetById;
using Application.Features.SupportRequests.Queries.GetList;
using Core.Requests;
using Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportRequestController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSupportRequestCommand command)
        {
            CreateSupportRequestResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteSupportRequestCommand command = new() { Id = id };
            DeleteSupportRequestResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("soft-delete/{id}")]
        public async Task<IActionResult> SoftDelete([FromRoute] int id)
        {
            SoftDeleteSupportRequestCommand command = new() { Id = id };
            SoftDeleteSupportRequestResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSupportRequestCommand command)
        {
            UpdateSupportRequestResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            GetByIdSupportRequestQuery query = new() { Id = id };
            GetByIdSupportRequestResponse response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            GetListSupportRequestQuery query = new() { PageRequest = pageRequest };
            GetListResponse<GetListSupportRequestResponse> response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
