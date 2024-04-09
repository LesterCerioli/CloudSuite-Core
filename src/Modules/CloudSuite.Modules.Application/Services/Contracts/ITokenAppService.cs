using CloudSuite.Domain.Models;
using CloudSuite.Modules.Application.Handlers.Tokens;
using CloudSuite.Modules.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Contracts
{
    public interface ITokenAppService
    {

        Task<JwtTokenViewModel> GetByPublicToken(string? publicKey);

        Task<JwtTokenViewModel> GetByPvToken(string? privateToken);

        Task<JwtTokenViewModel> GetByEncryToken(string? encryptedToken);

        Task SaveAsync(CreateJwtTokenCommand commandCreate);
    }
}
