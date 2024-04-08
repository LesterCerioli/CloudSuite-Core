using CloudSuite.Modules.Application.Handlers.Company;
using CloudSuite.Modules.Application.Handlers.Company.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CloudSuite.Services.Core.Api.Controllers.V1.Core
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyApiController : ControllerBase
    {
        private readonly ILogger<CompanyApiController> _logger;
        private readonly IMediator _mediator;

        public CompanyApiController(ILogger<CompanyApiController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateCompanyCommand commandCreate)
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
        [Route("exists/cnpj/{cnpj}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CnpjExists([FromRoute] string cnpj)
        {
            var result = await _mediator.Send(new CheckCompanyExistsByCnpjRequest(cnpj));
            if (result.Errors.Any())
            {
                return BadRequest(result);
            }
            if (result.Exists)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }

        }

        [HttpGet]
        [Route("exists/company/{fantasyName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FantasyNameExists([FromBody] string fantasyName)
        {
            var result = await _mediator.Send(new CheckCompanyExistsByFantasyNameRequest(fantasyName));

            if (result.Errors.Any())
            {
                return BadRequest(result);
            }
            if (result.Exists)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        [HttpGet]
        [Route("exists/company/{registerName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterNameExists([FromBody] string registerName)
        {
            var result = await _mediator.Send(new CheckCompanyExistsByRegisterNameRequest(registerName));
            if (result.Errors.Any())
            {
                return BadRequest(result);
            }
            if (result.Exists)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }


    }
}
