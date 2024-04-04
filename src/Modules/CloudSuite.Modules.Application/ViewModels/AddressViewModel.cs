using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CloudSuite.Modules.Application.ViewModel
{
    public class AddressViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Nome de Contato")]
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(100)]
        public string? ContactName { get; set; }

        [DisplayName("Endereço Completo")]
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? AddressLine1 { get; set; }

        [DisplayName("Cidade")]
        public string? City { get; set; }
        
        [DisplayName("Bairro")]
        public string? District { get; set; }
    }
}