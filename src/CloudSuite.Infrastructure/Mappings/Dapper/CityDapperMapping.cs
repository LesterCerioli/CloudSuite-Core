using CloudSuite.Domain.Models;
using Dapper;
using Dapper.FluentMap.Dommel.Mapping;
using Microsoft.IdentityModel.Tokens;
using System.Data;

namespace CloudSuite.Infrastructure.Mappings.Dapper
{
    public class CityDapperMapping
    {
        private readonly IDbConnection _connection;
        public CityDapperMapping(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<City>> GetAllCitiesAsync()
        {
            var query = @"SELECT CityName FROM Cities";

            return await _connection.QueryAsync<City>(query);
        }

        public async Task<City> GetCityByCityName(string cityName)
        {
            var query = @"SELECT CityName FROM Cities WHERE CityName = @CityCityName";
            return await _connection.QueryFirstOrDefaultAsync<City>(query, new { CityCityName = cityName });
        }
        
    }
}