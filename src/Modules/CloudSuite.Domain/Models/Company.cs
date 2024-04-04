using NetDevPack.Domain;
using CloudSuite.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Models
{
    public class Company : Entity, IAggregateRoot
    {
        private Cnpj cnpj;

        public Company(Guid id, Cnpj cnpj, string? fantasyName, string? registerName, Address address) {
            AddressId = id;
            Cnpj = cnpj;
            FantasyName = fantasyName;
            RegisterName = registerName;
            Address = address;
        }

        public Company(Guid id, Cnpj cnpj, string? fantasyName, string? registerName)
        {
            AddressId = id;
            Cnpj = cnpj;
            FantasyName = fantasyName;
            RegisterName = registerName;
        }

        public Company(Cnpj cnpj, string? fantasyName, string? registerName)
        {
            this.cnpj = cnpj;
            FantasyName = fantasyName;
            RegisterName = registerName;
        }

        public Cnpj Cnpj { get; set; }

        public Guid CnpjID { get; private set; }

        [Required(ErrorMessage = "Este campo � de preenchimento obrigat�rio.")]
        [MaxLength(100)]
        public string? FantasyName { get; private set; }

        [Required(ErrorMessage = "Este campo � de preencimento obrigat�rio.")]
        [MaxLength(100)]
        public string? RegisterName { get; private set; }

        public Address Address { get; private set; }

        public Guid AddressId { get; private set; }
    }
}