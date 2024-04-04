using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.ValueObjects
{
	public class Name : ValueObject
	{
		private string? name;

		public Name(string? name)
		{
			this.name = name;
		}

		public Name(string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;
		}

		public string FirstName { get; private set; }
		public string LastName { get; private set; }

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return FirstName;
			yield return LastName;
		}
	}
}
