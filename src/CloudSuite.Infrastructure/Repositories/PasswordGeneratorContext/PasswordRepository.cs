using CloudSuite.Domain.Contracts.PasswordGeneratorContext;
using CloudSuite.Domain.Models.PasswordGeneratorContext;
using CloudSuite.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Repositories.PasswordGeneratorContext
{
	public class PasswordRepository : IPasswordRepository
	{

		protected readonly CoreDbContext Db;
		protected readonly DbSet<Password> DbSet;

		public PasswordRepository(CoreDbContext context)
		{
			Db = context;
			DbSet = context.Passwords;
		}

		public async Task Add(Password password)
		{
			await Task.Run(() =>
			{
				DbSet.Add(password);
				Db.SaveChangesAsync();
			});
		}

		public async Task<Password> GetByCaracter(int caracterNumber)
		{
			return await DbSet.FirstOrDefaultAsync(c => c.CaracterNumber == caracterNumber);
		}

		public async Task<Password> GetBySecret(string senha)
		{
			return await DbSet.FirstOrDefaultAsync(c => c.Senha == senha);
		}

		public async Task<IEnumerable<Password>> GetList()
		{
			return await DbSet.ToListAsync();
		}

		public void Remove(Password password)
		{
			DbSet?.Remove(password);
		}

		public void Update(Password password)
		{
			DbSet.Update(password);
		}

		public void Dispose()
		{
			Db.Dispose();
		}
	}
}
