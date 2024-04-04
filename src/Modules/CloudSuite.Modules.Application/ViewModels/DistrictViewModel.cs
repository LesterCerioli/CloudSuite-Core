using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.ViewModels
{
	public class DistrictViewModel
	{
		[Key]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "The {0} field is required.")]
		[StringLength(450)]
		[DisplayName("Nome")]
		public string Name { get; set; }

		[Required(ErrorMessage = "The {0} field is required.")]
		[DisplayName("Tipo")]
		public string Type { get; set; }

		[Required(ErrorMessage = "The {0} field is required.")]
		[StringLength(100)]
		[DisplayName("Localizacao")]
		public string Location { get; set; }
	}
}
