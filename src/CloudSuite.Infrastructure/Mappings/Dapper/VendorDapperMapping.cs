using CloudSuite.Domain.Models;
using Dapper;
using Dapper.FluentMap.Dommel.Mapping;
using System.Data;

namespace CloudSuite.Infrastructure.Mappings.Dapper
{
    public class VendorDapperMapping
    {
        private readonly IDbConnection _connection;
        public VendorDapperMapping(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Vendor>> GetAllVendorsAsync()
        {
            var query = @"SELECT Name, Slug, Description, CNPJNumber, EmailId, CreatedOn,
                          LatestUpdatedOn, IsActive, IsDeleted FROM Users";

            return await _connection.QueryAsync<Vendor>(query);
        }

        public async Task<Vendor> GetVendorByCnpjAsync(string vendorCnpj)
        {
            var query = @"
                SELECT 
                    CNPJNumber
                FROM
                    Vendors
                WHERE
                    CNPJNumber = @VendorCNPJNumber";

            return await _connection.QueryFirstOrDefaultAsync<Vendor>(query, new { VendorCNPJNumber = vendorCnpj });
        }

        public async Task<Vendor> GetVendorByNameAsync(string vendorName)
        {
            var query = @"
                SELECT 
                    Name
                FROM
                    Vendors
                WHERE
                    Name = @VendorName";

            return await _connection.QueryFirstOrDefaultAsync<Vendor>(query, new { VendorName = vendorName });
        }

        public async Task<Vendor> GetVendorByCreatedOnAsync(DateTimeOffset vendorCreatedOn)
        {
            var query = @"
                SELECT 
                    CreatedOn
                FROM
                    Vendors
                WHERE
                    CreatedOn = @VendorCreatedOn";

            return await _connection.QueryFirstOrDefaultAsync<Vendor>(query, new { VendorCreatedOn = vendorCreatedOn });
        }

    }
}