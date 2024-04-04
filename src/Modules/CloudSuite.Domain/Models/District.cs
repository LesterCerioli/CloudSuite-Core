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
            _cities = new List<City>(0);
            Name = name;
            Type = type;
            Location = location;
        }

        public District() { }

        public District(string? name, string? type, string? location)
        {
            Name = name;
            Type = type;
            Location = location;
        }

        public IReadOnlyCollection<City> Cities => _cities.AsReadOnly();

        public City City { get; private set; }

        public Guid CityId { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? Name { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string? Type {  get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(100)]
        public string? Location { get; private set; }
    }
}