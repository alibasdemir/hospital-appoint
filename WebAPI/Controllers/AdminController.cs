//using Application.Features.Admins.Commands.Create;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace WebAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AdminController : BaseController
//    {
//        [HttpPost]
//        public async Task<IActionResult> Add([FromBody] CreateAdminCommand command)
//        {
//            CreateAdminResponse response = await _mediator.Send(command);
//            return Ok(response);
//        }
//    }
//}
