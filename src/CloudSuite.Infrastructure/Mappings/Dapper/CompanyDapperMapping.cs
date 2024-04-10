using CloudSuite.Domain.Models;
using Dapper;
using Dapper.FluentMap.Dommel.Mapping;
using System.Data;

namespace CloudSuite.Infrastructure.Mappings.Dapper
{
    public class CompanyDapperMapping
    {
        private readonly IDbConnection _connection;
        public CompanyDapperMapping(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            var query = @"SELECT CNPJNumber, FantasyName, RegisterName From Companies";
            
            return await _connection.QueryAsync<Company>(query);
        }

        public async Task<Company> GetCompanyByCnpjAsync(string companyCnpj)
        {
            var query = @"
                SELECT 
                    CNPJNumber
                FROM
                    Companies
                WHERE
                    CNPJNumber = @CompanyCNPJ";

            return await _connection.QueryFirstOrDefaultAsync<Company>(query, new { CompanyCNPJ = companyCnpj });
        }

        public async Task<Company> GetCompanyByFantasyNameAsync(string companyFantasyName)
        {
            var query = @"
                SELECT 
                    FantasyName
                FROM
                    Companies
                WHERE
                    FantasyName = @CompanyFantasyName";

            return await _connection.QueryFirstOrDefaultAsync<Company>(query, new { CompanyFantasyName = companyFantasyName });
        }

        public async Task<Company> GetCompanyBySocialNameAsync(string companyRegisterName)
        {
            var query = @"
                SELECT 
                    RegisterName
                FROM
                    Companies
                WHERE
                    RegisterName = @CompanyRegisterlName";

            return await _connection.QueryFirstOrDefaultAsync<Company>(query, new { CompanyRegisterlName = companyRegisterName });
        }

    }
}