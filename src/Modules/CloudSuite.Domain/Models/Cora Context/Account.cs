using NetDevPack.Domain;

namespace CloudSuite.Domain.Models.Cora_Context
{
    public class Account : Entity, IAggregateRoot
    {

        public Account(string? agency, string? accountNumber, 
            string? accountDigit, string? bankName, 
            string? bankCode)
        {
            Agency = agency;
            AccountNumber = accountNumber;
            AccountDigit = accountDigit;
            BankName = bankName;
            BankCode = bankCode;
        }

        public string? Agency { get; private set; }

        public string? AccountNumber { get; private set;}

        public string? AccountDigit { get; private set;}

        public string? BankName { get; private set;}

        public string? BankCode { get; private set;}
    }
}
