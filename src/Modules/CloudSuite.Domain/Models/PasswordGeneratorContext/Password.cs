using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Models.PasswordGeneratorContext
{
	public class Password : Entity, IAggregateRoot
	{
		public Password(string? senha, int? caracterNumber, DateTimeOffset? createdOn)
		{
			Senha = senha;
			CaracterNumber = caracterNumber;
			CreatedOn = DateTime.Now;
		}

		public Password() { }

		public string? Senha { get; private set; }

		public int? CaracterNumber { get; private set; }

		public DateTimeOffset? CreatedOn { get; private set; }
	}
}
