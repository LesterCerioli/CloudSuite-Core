using CloudSuite.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.ViewModels
{
	public class EmailViewModel
	{
		[Key]
		public Guid Id { get; set; }

		[DisplayName("Assunto")]
		public string Subject { get; set; } // Email subject

		[DisplayName("Corpo Email")]
		public string Body { get; set; } // Email body content

		[DisplayName("Remetente")]
		public string Sender { get; set; } // Email sender's address

		[DisplayName("Destinaraeio")]
		public string? Recipient { get; set; } // Email recipient's address

		[DisplayName("Data Hora de Envio")]
		public DateTimeOffset? SentDate { get; set; } // Date and time when the email was sent

		[DisplayName("Tentativas de Envio")]
		public int SendAttempts { get; private set; } // Number of send attempts

		[DisplayName("Código de Erro")]
		public string CodeErrorEmail { get; private set; }
	}
}
