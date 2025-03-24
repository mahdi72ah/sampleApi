using MediatR;
using Microsoft.AspNetCore.Mvc;
using sampleApi.Application.CQRS.LoginCommandQuery.Command;

namespace sampleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticateController:ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticateController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand loginCommand)
        {
            var result = await _mediator.Send(loginCommand);
            return Ok(result);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterCommand registerCommand)
        {
            var result = await _mediator.Send(registerCommand);
            return Ok(result);
        }
    }
}
