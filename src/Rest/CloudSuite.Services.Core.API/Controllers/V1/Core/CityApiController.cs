using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using CloudSuite.Modules.Application.Hadlers.City;
using CloudSuite.Modules.Application.Hadlers.City.Request;

namespace CloudSuite.Services.Core.Api.Controllers.V1.Core
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CityApiController : ControllerBase
    {
        private readonly ILogger<CityApiController> _logger;
        private readonly IMediator _mediator;

        public CityApiController(ILogger<CityApiController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateCityCommand commandCreate)
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

        [Authorize]
        [HttpGet]
        [Route("exists/city/{cityName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CititsExists([FromRoute] string cityName)
        {
            var result = await _mediator.Send(new CheckCityExistsByCityNameRequest(cityName));
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
