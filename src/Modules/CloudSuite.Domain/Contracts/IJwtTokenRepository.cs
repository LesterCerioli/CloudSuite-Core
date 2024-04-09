using CloudSuite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Contracts
{
    public interface IJwtTokenRepository
    {
        Task<JwtToken> GetByPublicToken(string? publicKey);

        Task<JwtToken> GetByPvToken(string? privateToken);

        Task<JwtToken> GetByEncryToken(string? encryptedToken);

        Task Add(JwtToken token);

        void Update(JwtToken token);

        void Remove(JwtToken token);
    }
}
