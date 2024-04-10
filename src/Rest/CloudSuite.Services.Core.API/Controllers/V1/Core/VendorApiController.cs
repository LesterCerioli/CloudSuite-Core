using CloudSuite.Domain.ValueObjects;
using CloudSuite.Modules.Application.Handlers.User.Request;
using CloudSuite.Modules.Application.Handlers.Vendor;
using CloudSuite.Modules.Application.Handlers.Vendor.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CloudSuite.Services.Core.Api.Controllers.V1.Core
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorApiController : ControllerBase
    {
        private readonly IMediator _mediator;
        private ILogger<VendorApiController> _logger;

        public VendorApiController(ILogger<VendorApiController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [AllowAnonymous]
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateVendorCommand commandCreate)
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


        [HttpGet("exists/cnpj")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CnpjExists([FromBody] string cnpj)
        {
            // Ensure CPF is not null or empty
            if (string.IsNullOrEmpty(cnpj))
            {
                return BadRequest("CNPJ is required.");
            }

            var result = await _mediator.Send(new CheckVendorExistsByCnpjRequest(cnpj));
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
