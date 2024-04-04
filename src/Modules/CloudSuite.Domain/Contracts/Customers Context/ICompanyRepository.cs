using CloudSuite.Domain.Models;
using CloudSuite.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Contracts.Customers_Context
{
	public interface ICompanyRepository
	{
		Task<Company> GetByCnpj(Cnpj cnpj);

		Task<Company> GetBySocialName(string socialName);

		Task<Company> GetByFantasyName(string fantasyName);

		Task<IEnumerable<Company>> GetCompanies();

		Task Add(Company company);

		void Updater(Company company);	

		void Remove(Company company);
	}
}
