using Application.Features.Auth.Commands.ChangePassword;
using Application.Features.Auth.Commands.Login;
using Application.Features.Auth.Commands.Register;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand)
        {
            RegisterResponse response = await _mediator.Send(registerCommand);
            return Ok(response);
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand)
        {
            var response = await _mediator.Send(loginCommand);
            return Ok(response);
        }

        [HttpPut("ChangePassword")]
        public async Task<IActionResult> Update([FromBody] ChangePasswordCommand command)
        {
            ChangePasswordResponse response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
