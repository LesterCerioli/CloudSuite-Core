using CloudSuite.Domain.Models.Customers_Context;
using CloudSuite.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customer = CloudSuite.Domain.Models.Customers_Context.Customer;

namespace CloudSuite.Domain.Contracts.Customers_Context
{
	public interface ICustomerRepository
	{
		Task<Customer> GetByName(Name name);

		Task<Customer> GetByCnpj(Cnpj cnpj);

		Task Add(Customer customer);

		Task<IEnumerable<Customer>> GetAll();	

		void Update(Customer customer);

		void remove(Customer customer);
	}
}
