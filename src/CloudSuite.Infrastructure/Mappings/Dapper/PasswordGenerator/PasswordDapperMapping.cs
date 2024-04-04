using CloudSuite.Domain.Models.PasswordGeneratorContext;
using CloudSuite.Infrastructure.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Mappings.Dapper.PasswordGenerator
{
	public class PasswordDapperMapping
	{


		private readonly IDbConnection _connection;

		public CoreDbContext CoreDbContext { get; set; }

		public PasswordDapperMapping(CoreDbContext context)
		{
			CoreDbContext = context;
			_connection = context.Database.GetDbConnection();
		}



		public async Task<IEnumerable<Password>> GetAllPasswordAsync()
		{
			var query = @"
				SELECT
					Id,
					Caracter,
					CreateOn
				FROM
					Passwords";
			return await _connection.QueryAsync<Password>(query);
		}
	}
}
