

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CloudSuite.Modules.Application.ViewModel
{
    public class CityViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo � de preenchimento obrigat�rio.")]
        [MaxLength(100)]

        [DisplayName("NomeCidade")]
        public string? CityName { get; set; }

        [DisplayName("Estado")]
        public string? State { get; set; }
    }
}