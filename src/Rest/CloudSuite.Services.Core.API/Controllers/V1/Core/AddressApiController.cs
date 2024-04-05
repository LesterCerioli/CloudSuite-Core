using CloudSuite.Modules.Application.Hadlers.Address;
using CloudSuite.Modules.Application.Hadlers.Address.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using FromBodyAttribute = System.Web.Http.FromBodyAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

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

        public async Task<IActionResult> AddressLineExists([FromBody] string addressLine)
        {
            var result = await _mediator.Send(new CheckAddressExistsByAddressLineResponse(addressLine));
        }


        // GET: api/<AddressApiController>
        [HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		
	}
}
