using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Models.Cora_Context.Payments
{
    public class Pagamento : Entity, IAggregateRoot
    {
        public string? PaymentNumber { get; private set; }
        public string? Amount { get; private set; }
        public PaymentHistory PaymentHistory { get; private set; }

        public Pagamento(string? paymentNumber, string? amount, PaymentHistory paymentHistory)
        {
            PaymentNumber = paymentNumber;
            Amount = amount;
            PaymentHistory = paymentHistory;
        }
    }
}
