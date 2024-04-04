
using CloudSuite.Domain.Models.PasswordGeneratorContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Contracts.PasswordGeneratorContext
{
	public interface IPasswordRepository
	{
		Task<Password> GetByCaracter(int caracterNumber);

		Task<Password> GetBySecret(string senha);

		Task<IEnumerable<Password>> GetList();
		
		Task Add(Password password);

		void Update(Password password);

		void Remove(Password password);
	}
}
