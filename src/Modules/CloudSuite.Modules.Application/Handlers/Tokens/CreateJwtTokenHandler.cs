using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.Tokens.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Tokens
{
    public class CreateJwtTokenHandler : IRequestHandler<CreateJwtTokenCommand, CreateJwtTokenResponse>
    {
        private readonly ILogger<CreateJwtTokenHandler> _logger;
        private readonly IJwtTokenRepository _jwtTokenRepository;

        public CreateJwtTokenHandler(ILogger<CreateJwtTokenHandler> logger, IJwtTokenRepository jwtTokenRepository)
        {
            _logger = logger;
            _jwtTokenRepository = jwtTokenRepository;

        }


        public async Task<CreateJwtTokenResponse> Handle(CreateJwtTokenCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
