using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.ViewModels
{
	public class MediaViewModel
	{
		[Key]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
		[StringLength(450)]
		[DisplayName("Caption")]
		public string Caption { get; set; }

		[Required(ErrorMessage = "Este campo é obrigatório.")]
		[DisplayName("Tamanho Arquivo")]
		public int FileSize { get; set; }

		[Required(ErrorMessage = "Este campo é de preencimento obrigatório.")]
		[StringLength(450)]
		[DisplayName("Nome Arquivo")]
		public string FileName { get; set; }
	}
}
