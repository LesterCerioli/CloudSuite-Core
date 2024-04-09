using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.Tokens;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Implementations
{
    public class TokenService : ITokenAppService
    {
        private readonly IJwtTokenRepository _jwtTokenRepository;
        private readonly IMediatorHandler _mediator;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config; // Change object to IConfiguration

        public TokenService(
            IJwtTokenRepository jwtTokenRepository,
            IMediatorHandler mediator,
            IMapper mapper,
            IConfiguration config) // Adjust the constructor parameter
        {
            _jwtTokenRepository = jwtTokenRepository;
            _mediator = mediator;
            _mapper = mapper;
            _config = config; // Assign the provided IConfiguration instance to _config
        }

        public async Task<JwtTokenViewModel> GetByEncryToken(string? encryptedToken)
        {
            return _mapper.Map<JwtTokenViewModel>(await _jwtTokenRepository.GetByEncryToken(encryptedToken));
        }

        public async Task<JwtTokenViewModel> GetByPublicToken(string? publicKey)
        {
            return _mapper.Map<JwtTokenViewModel>(await _jwtTokenRepository.GetByPublicToken(publicKey));
        }

        public async Task<JwtTokenViewModel> GetByPvToken(string? privateToken)
        {
            return _mapper.Map<JwtTokenViewModel>(await _jwtTokenRepository.GetByPvToken(privateToken));
        }

        public async Task SaveAsync(CreateJwtTokenCommand commandCreate)
        {
            await _jwtTokenRepository.Add(commandCreate.GetEntity());
        }

        public string GenerateToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "yourUserName")
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
