using CloudSuite.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.ViewModels
{
	public class StateViewModel
	{
		[Key]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
		[StringLength(100)]
		[DisplayName("Nome Estado")]
		public string StateName { get; set; }

		[Required(ErrorMessage = "Este cmapo é de preenchimento obrigatório.")]

		[DisplayName("UF")]
		public string UF { get; set; }

		[DisplayName("País")]
		public string Country { get; set; }
	}
}
