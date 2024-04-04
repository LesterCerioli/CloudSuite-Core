using CloudSuite.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Models.Cora_Context.Payments
{
    public class Customer
    {
        public Customer(Cnpj cnpj, string? socialReason, string? responsibleContatct, Telephone telephone)
        {
            Cnpj = cnpj;
            SocialReason = socialReason;
            ResponsibleContact = responsibleContatct;
            Telephone = telephone;
        }

        public Cnpj Cnpj { get; private set; }
        public string? SocialReason {  get; private set; }
        public string? ResponsibleContact {  get; private set; }
        public Telephone Telephone {  get; private set; }

        
    }
}
