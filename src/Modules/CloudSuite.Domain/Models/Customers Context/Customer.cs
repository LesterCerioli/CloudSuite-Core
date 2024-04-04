using CloudSuite.Domain.ValueObjects;
using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CloudSuite.Domain.Models.Customers_Context
{
	public class Customer : Entity, IAggregateRoot
	{
		public Customer()
		{
		}

		public Customer(Name name, Cnpj cnpj, Email email, string? businessOwner, DateTimeOffset? createdOn,
			Company company)
		{
			Name = name;
			Cnpj = cnpj;
			Email = email;
			BusinessOwner = businessOwner;
			CreatedOn = createdOn;
			Company = company;
		}

		public Customer(Name name, Cnpj cnpj, Email email, string? businessOwner, DateTimeOffset? createdOn)
		{
			Name = name;
			Cnpj = cnpj;
			Email = email;
			BusinessOwner = businessOwner;
			CreatedOn = createdOn;
		}

		public Name Name { get; private set; }

		public Cnpj Cnpj { get; private set; }

		public Email Email { get; private set; }

		public string? BusinessOwner { get; private set; }

		public DateTimeOffset? CreatedOn { get; private set; }

		public Company Company { get; private set; }
	}
}
