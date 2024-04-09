using CloudSuite.Modules.Application.Handlers.District;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CloudSuite.Services.Core.Api.Controllers.V1.Core
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictApiController : ControllerBase
    {
        private readonly ILogger<DistrictApiController> _logger;
        private readonly IMediator _mediator;

        public DistrictApiController(ILogger<DistrictApiController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        [AllowAnonymous]
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateDistrictCommand commandCreate)
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
