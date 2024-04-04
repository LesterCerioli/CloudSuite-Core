using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Diagnostics.Metrics;

namespace CloudSuite.Domain.Models
{
    public class State : Entity, IAggregateRoot
    {
        private readonly List<Country> _countries;
        private object value;

        public State(Guid id, string uf, string stateName, Country country, Guid countryId)
        {
            Id = id;
            _countries = new List<Country>();
            UF = uf;
            StateName = stateName;
            Country = country;
            CountryId = countryId;
        }

        public State(Guid id, string uf, string stateName, Guid countryId)
        {
            Id = id;
            _countries = new List<Country>();
            UF = uf;
            StateName = stateName;
            CountryId = countryId;
        }

        public State()
        {

        }

        public State(string? uF, string? stateName, object value)
        {
            UF = uF;
            StateName = stateName;
            this.value = value;
        }

		public State(string? uF, string? stateName)
		{
			UF = uF;
			StateName = stateName;
		}

		[Required(ErrorMessage="Este campo � de preenchimento obrigat�rio.")]
        [StringLength(100)]
        public string? StateName { get; private set; }

        [Required(ErrorMessage = "Este cmapo � de preenchimento obrigat�rio.")]

        public string? UF { get; private set; }

        public Country Country { get; private set; }

        public Guid CountryId { get; private set; }

        public IReadOnlyCollection<Country> Countries => _countries.AsReadOnly();
    }
}