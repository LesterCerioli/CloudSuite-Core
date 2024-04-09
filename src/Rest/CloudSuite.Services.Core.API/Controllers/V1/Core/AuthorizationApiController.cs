using CloudSuite.Modules.Application.Hadlers.Address;
using CloudSuite.Modules.Application.Handlers.Tokens;
using CloudSuite.Modules.Application.Services.Contracts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CloudSuite.Services.Core.Api.Controllers.V1.Core
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationApiController : ControllerBase
    {
        private readonly ILogger<AuthorizationApiController> _logger;
        private readonly IMediator _mediator;
        private readonly ITokenAppService _tokenService;

        public AuthorizationApiController(ILogger<AuthorizationApiController> logger, IMediator mediator, ITokenAppService tokenService)
        {
            _logger = logger;
            _mediator = mediator;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("generate-token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GenerateToken([FromBody] CreateJwtTokenCommand commandCreate)
        {
            var result = await _mediator.Send(commandCreate);
            if (result.Errors.Any())
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }

        
    }
}
