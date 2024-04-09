using CloudSuite.Modules.Application.Handlers.Tokens.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JwtTokenEntity = CloudSuite.Domain.Models.JwtToken;

namespace CloudSuite.Modules.Application.Handlers.Tokens
{
    public class CreateJwtTokenCommand : IRequest<CreateJwtTokenResponse>
    {
        public Guid Id { get; private set; }

        public string? EncryptedToken { get; set; }

        public string? PublicKey { get; set; }

        public string? PrivateKey { get; set; }

        public JwtTokenEntity GetEntity()
        {
            return new JwtTokenEntity(
                this.PublicKey,
                this.PrivateKey,
                this.EncryptedToken);
        }

    }
}
