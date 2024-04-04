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
	public class VendorViewModel
	{
		[Key]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "The {0} field is required.")]
		[StringLength(450)]
		[DisplayName("Nome")]
		public string Name { get; set; }

		[Required(ErrorMessage = "The {0} field is required.")]
		[StringLength(450)]
		[DisplayName("Slug")]
		public string Slug { get; set; }

		[Required(ErrorMessage = "The {0} field is required.")]
		[StringLength(100)]
		[DisplayName("Descricao")]
		public string Description { get; set; }

		[DisplayName("Cnpj")]
		public string Cnpj { get; set; }

		[DisplayName("Email")]
		public string Email { get; set; }

		[DisplayName("Data Criacao")]
		public DateTimeOffset CreatedOn { get; set; }

		[DisplayName("Data Atualizacao")]
		public DateTimeOffset LatestUpdatedOn { get; set; }
	}
}
