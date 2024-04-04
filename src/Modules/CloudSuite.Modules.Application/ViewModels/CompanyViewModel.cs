using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.ViewModels
{
	public class CompanyViewModel
	{
		[Key]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
		[MaxLength(100)]
		[DisplayName("Nome Fantasia")]
		public string FantasyName { get; set; }

		[Required(ErrorMessage = "Este campo é de preencimento obrigatório.")]
		[MaxLength(100)]
		[DisplayName("Razao Social")]
		public string? RegisterName { get; set; }
	}
}
