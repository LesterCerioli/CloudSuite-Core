using CloudSuite.Domain.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CloudSuite.Infrastructure.Mappings.Dapper
{
    public class AddressDapperMapping
    {
        private readonly IDbConnection _connection;
        public AddressDapperMapping(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Address>> GetAllAddressesAsync()
        {
            var query = @"
                        SELECT
                            ContactName,
                            AddressLine
                        FROM
                            Addresses";

            return await _connection.QueryAsync<Address>(query);
        }

        public async Task<Address> GetByContactNameAsync(string contactName)
        {
            var query = @"
                        SELECT
                            ContactName
                        FROM
                            Addresses
                        WHERE
                            ContactName = @AddressContactName";

            return await _connection.QueryFirstOrDefaultAsync<Address>(query, new { AddressContactName = contactName });
        }

        public async Task<Address> GetByAddressLineAsync(string addressLine)
        {
            var query = @"
                        SELECT
                            AddressLine
                        FROM
                            Addresses
                        WHERE
                            AddressLine = @AddressAddressLine";

            return await _connection.QueryFirstOrDefaultAsync<Address>(query, new { AddressContactName = addressLine });
        }

    }
}