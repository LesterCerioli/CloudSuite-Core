using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Models.Cora_Context
{
    public class Transfer : Entity, IAggregateRoot
    {
        public Transfer(Account account,
            string? amount,
            string? description,
            string? code,
            string? category,
            DateTimeOffset? creationDate,
            string? bankCodeRecipient, 
            string? branchNumberRecipient,
            string? accountNumberRecipient,
            DateTimeOffset scheduled,
            string? accountType,
            string? status)
        {
            Account = account;
            Amount = amount;
            Description = description;
            Code = code;
            Category = category;
            CreationDate = creationDate;
            BankCodeRecipient = bankCodeRecipient;
            BranchNumberRecipient = branchNumberRecipient;
            AccountNumberRecipient = accountNumberRecipient;
            Scheduled = scheduled;
            AccountType = accountType;
            Status = status;
        }

        public Account Account { get; private set; }
        public string? Amount {  get; private set; }
        public string? Description {  get; private set; }
        public string? Code {  get; private set; }
        public string? Category {  get; private set; }
        public DateTimeOffset? CreationDate {  get; private set; }

        //Código de Banco de Destinatário
        public string? BankCodeRecipient {  get; private set; }
        public string? BranchNumberRecipient {  get; private set; }
        public string? AccountNumberRecipient {  get; private set; }

        //Data de Agendamento - Scheduling Date
        public DateTimeOffset Scheduled {  get; private set; }
        public string? AccountType {  get; private set; }
        public string? Status {  get; private set; }
    }
}
