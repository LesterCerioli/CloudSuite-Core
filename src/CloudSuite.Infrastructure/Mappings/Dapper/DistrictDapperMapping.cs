using CloudSuite.Domain.Models;
using Dapper;
using Dapper.FluentMap.Dommel.Mapping;
using System.Data;

namespace CloudSuite.Infrastructure.Mappings.Dapper
{
    public class DistrictDapperMapping
    {
        private readonly IDbConnection _connection;

        public DistrictDapperMapping(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<District>> GetAllDistrictsAsync()
        {
            var query = @"SELECT Name, Type, Location, CityId FROM Districts";
            return await _connection.QueryAsync<District>(query);
        }

        public async Task<District> GetDistrictByNameAsync(string districtName)
        {
            var query = @"
                SELECT 
                    Name
                FROM
                    Districts
                WHERE
                    Name = @DistrictName";

            return await _connection.QueryFirstOrDefaultAsync<District>(query, new { DistrictName = districtName });
        }

    }
}