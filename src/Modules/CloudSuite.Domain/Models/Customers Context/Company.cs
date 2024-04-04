using CloudSuite.Domain.ValueObjects;
using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Models.Customers_Context
{
	public class Company : Entity, IAggregateRoot
	{
		public Company(Cnpj cnpj, string? socialName, string? fantasyName, DateTime fundationDate)
		{
			Cnpj = cnpj;
			SocialName = socialName;
			FantasyName = fantasyName;
			FundationDate = fundationDate;
		}

		public Cnpj Cnpj { get; private set; }

		public string? SocialName { get; private set; }

		public string? FantasyName { get; private set; }

		public DateTime FundationDate { get; private set; }

		public Address Address { get; set; }
	}
}
