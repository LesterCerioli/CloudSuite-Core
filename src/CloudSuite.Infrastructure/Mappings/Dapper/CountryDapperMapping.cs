using CloudSuite.Domain.Models;
using Dapper;
using Dapper.FluentMap.Dommel.Mapping;
using System.Data;

namespace CloudSuite.Infrastructure.Mappings.Dapper
{
    public class CountryDapperMapping
    {
        private readonly IDbConnection _connection;
        public CountryDapperMapping(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Country>> GetAllCountriesAsync()
        {
            var query = @"SELECT CountryName, Code, IsBillingEnabled, IsShippingEnabled, 
                          IsCityEnabled, IsZipCodeEnabled, IsDistrictEnabled, StateId
                          FROM Companies";

            return await _connection.QueryAsync<Country>(query);
        }

        public async Task<Country> GetCountryByCodeAsync(string companyCode)
        {
            var query = @"
                SELECT 
                    Code
                FROM
                    Companies
                WHERE
                    Code = @CountrCode";

            return await _connection.QueryFirstOrDefaultAsync<Country>(query, new { CountryCode = companyCode });
        }

        public async Task<Country> GetCountryByNameAsync(string countryName)
        {
            var query = @"
                SELECT 
                    CountryName
                FROM
                    Companies
                WHERE
                    CountryName = @CompanyName";

            return await _connection.QueryFirstOrDefaultAsync<Country>(query, new { CompanyName = countryName });
        }
    }
}