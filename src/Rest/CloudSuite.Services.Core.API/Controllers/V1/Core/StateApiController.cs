using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using CloudSuite.Modules.Application.Handlers.State;
using CloudSuite.Modules.Application.Handlers.State.Request;

namespace CloudSuite.Services.Core.Api.Controllers.V1.Core
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateApiController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<StateApiController> _logger;

        public StateApiController(ILogger<StateApiController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateStateCommand commandCreate)
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


        [HttpGet]
        [Route("exists/state/{stateName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> StateExists([FromRoute] string stateName)
        {
            var result = await _mediator.Send(new CheckStateExistsByNameRequest(stateName));
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
