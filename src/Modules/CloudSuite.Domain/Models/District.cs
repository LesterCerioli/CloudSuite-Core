using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CloudSuite.Domain.Models
{
    public class District : Entity, IAggregateRoot
    {

        private readonly List<City> _cities;

        public District(Guid id, string name, string type, string location)
        {
            Id = id;
            _cities = new List<City>();
            Name = name;
            Type = type;
            Location = location;
        }

        protected District() 
        {
            _cities = new List<City>();
        }

    
        public IReadOnlyCollection<City> Cities => _cities.AsReadOnly();

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(100)] // ✅ Reduzido de 450
        public string Name { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(50)] // ✅ Adicione tamanho máximo
        public string Type { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(100)]
        public string Location { get; private set; }
    }
}