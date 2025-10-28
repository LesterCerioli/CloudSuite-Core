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
        
        protected Company() { } // ← ADICIONE ESTE CONSTRUTOR

        public Company(Guid id, Cnpj cnpj, string? fantasyName, string? registerName, Address address) 
        {
            Id = id; // ← CORREÇÃO: Deve ser Id, não AddressId
            Cnpj = cnpj;
            FantasyName = fantasyName;
            RegisterName = registerName;
            Address = address;
            AddressId = address?.Id ?? Guid.Empty; // ← CORREÇÃO: Setar AddressId
        }

        public Company(Guid id, Cnpj cnpj, string? fantasyName, string? registerName)
        {
            Id = id; // ← CORREÇÃO: Deve ser Id
            Cnpj = cnpj;
            FantasyName = fantasyName;
            RegisterName = registerName;
        }

        public Company(Cnpj cnpj, string? fantasyName, string? registerName)
        {
            Cnpj = cnpj;
            FantasyName = fantasyName;
            RegisterName = registerName;
        }

        public Cnpj Cnpj { get; private set; }

        
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [MaxLength(100)]
        public string? FantasyName { get; private set; }

        [Required(ErrorMessage = "Este campo é de preencimento obrigatório.")]
        [MaxLength(100)]
        public string? RegisterName { get; private set; }

        public Address Address { get; private set; }

        public Guid AddressId { get; private set; }
    }
}