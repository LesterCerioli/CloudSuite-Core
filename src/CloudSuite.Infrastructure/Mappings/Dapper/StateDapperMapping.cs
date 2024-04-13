using CloudSuite.Domain.Models;
using Dapper;
using Dapper.FluentMap.Dommel.Mapping;
using System.Data;

namespace CloudSuite.Infrastructure.Mappings.Dapper
{
    public class StateDapperMapping
    {
        private readonly IDbConnection _connection;
        public StateDapperMapping(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<State>> GetAllStatesAsync()
        {
            var query = @"SELECT StateName, UF, CountryId FROM States";
            return await _connection.QueryAsync<State>(query);
        }

        public async Task<State> GetStateByNameAsync(string stateName)
        {
            var query = @"
                SELECT 
                    StateName
                FROM
                    States
                WHERE
                    StateName = @StateName";

            return await _connection.QueryFirstOrDefaultAsync<State>(query, new { StateName = stateName });
        }

        public async Task<State> GetStateByUFAsync(string stateUF)
        {
            var query = @"
                SELECT 
                    UF
                FROM
                    States
                WHERE
                    UF = @StateUF";

            return await _connection.QueryFirstOrDefaultAsync<State>(query, new { StateUF = stateUF });
        }

    }
}