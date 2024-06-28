using Application.Features.Departments.Commands.Create;
using Application.Features.Departments.Commands.Delete;
using Application.Features.Departments.Commands.SoftDelete;
using Application.Features.Departments.Commands.Update;
using Application.Features.Departments.Queries.GetById;
using Application.Features.Departments.Queries.GetList;
using Application.Features.Feedbacks.Commands.Create;
using Application.Features.Feedbacks.Commands.Delete;
using Application.Features.Feedbacks.Commands.SoftDelete;
using Application.Features.Feedbacks.Commands.Update;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateFeedbackCommand command)
        {
            CreateFeedbackResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteFeedbackCommand command = new() { Id = id };
            await _mediator.Send(command);
            DeleteFeedbackResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("soft-delete/{id}")]
        public async Task<IActionResult> SoftDelete([FromRoute] int id)
        {
            SoftDeleteFeedbackCommand command = new() { Id = id };
            SoftDeleteFeedbackResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById([FromRoute] int id)
        //{
        //    GetByIdFeedbackQuery query = new() { Id = id };
        //    var result = await _mediator.Send(query);
        //    return Ok(result);
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetAll([FromQuery] GetListFeedbackQuery query)
        //{
        //    var result = await _mediator.Send(query);
        //    return Ok(result);
        //}

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFeedbackCommand command)
        {
            UpdateFeedbackResponse response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}