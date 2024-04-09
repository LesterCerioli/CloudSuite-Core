using CloudSuite.Modules.Application.Hadlers.Address;
using CloudSuite.Modules.Application.Hadlers.Address.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CloudSuite.Services.Core.Api.Controllers.V1.Core
{
	[Route("api/[controller]")]
	[ApiController]
	public class AddressApiController : ControllerBase
	{
        private readonly ILogger<AddressApiController> _logger;
        private readonly IMediator _mediator;

        public AddressApiController(ILogger<AddressApiController> logger, IMediator mediator)
		{
			_logger = logger;
			_mediator = mediator;

		}

        [AllowAnonymous]
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateAddressCommand commandCreate)
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
        [Route("exists/address/{addressline1}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddressLineExists([FromRoute] string addressLine1)
        {
            var result = await _mediator.Send(new CheckAddressExistsByAddressLineRequest(addressLine1));
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
