//using Application.Features.Auth.Commands.Register;
//using Microsoft.AspNetCore.Mvc;

//namespace WebAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AuthController : BaseController
//    {
//        [HttpPost("Register")]
//        public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand)
//        {
//            await _mediator.Send(registerCommand);
//            return Created();
//        }
//    }
//}
