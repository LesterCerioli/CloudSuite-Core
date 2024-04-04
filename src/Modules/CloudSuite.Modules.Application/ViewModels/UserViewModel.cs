using CloudSuite.Domain.Models;
using CloudSuite.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.ViewModels
{
	public class UserViewModel
	{
		[Required(ErrorMessage = "The {0} field is required.")]
		public string? FullName { get; set; }

		[DisplayName("Email")]
		public string Email { get; set; }


		[DisplayName("Cpf")]
		public string Cpf { get; set; }

		[DisplayName("Telefone")]
		public string Telephone { get; set; }

		[DisplayName("Data Criacao")]
		public DateTimeOffset CreatedOn { get; set; }

		[DisplayName("Data Atualizacao")]
		public DateTimeOffset LatestUpdatedOn { get; set; }

		
		
	}
}
