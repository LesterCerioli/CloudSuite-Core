using CloudSuite.Domain.Models;
using Dapper;
using Dapper.FluentMap.Dommel.Mapping;
using System.Data;

namespace CloudSuite.Infrastructure.Mappings.Dapper
{
    public class UserDapperMapping : DommelEntityMap<User>
    {
        private readonly IDbConnection _connection;
        public UserDapperMapping(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var query = @"SELECT FullName, IsDeleted, CPFNumber, TelephoneRegion,
                          TelephoneNumber, CreatedOn, LatestUpdatedOn, EmailId,
                          RefreshTokenHash FROM Users";

            return await _connection.QueryAsync<User>(query);
        }

        public async Task<User> GetUserByEmailAsync(string emailId)
        {
            var query = @"
                SELECT 
                    EmailId
                FROM
                    Users
                WHERE
                    EmailId = @UserEmailId";

            return await _connection.QueryFirstOrDefaultAsync<User>(query, new { UserEmailId = emailId });
        }
    }
}