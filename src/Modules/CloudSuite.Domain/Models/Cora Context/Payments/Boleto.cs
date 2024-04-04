using CloudSuite.Domain.ValueObjects;
using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Models.Cora_Context.Payments
{
    public class Boleto : Entity, IAggregateRoot
    {
        public Boleto(string? amountTotal, string? status, string? code, DateTimeOffset? createdAt, DateTimeOffset? finalizedAt, decimal? totalPaid, Method method, Pagamento pagamento, decimal? interest, decimal? fine)
        {
            AmountTotal = amountTotal;
            Status = status;
            Code = code;
            CreatedAt = createdAt;
            FinalizedAt = finalizedAt;
            TotalPaid = totalPaid;
            Method = method;
            Pagamento = pagamento;
            Interest = interest;
            Fine = fine;
        }

        public string? AmountTotal {  get; private set; }
        public string? Status { get; private set; }
        public string? Code { get; private set; }
        public DateTimeOffset? CreatedAt { get; private set;}
        public DateTimeOffset? FinalizedAt { get; private set;}
        public decimal? TotalPaid { get; private set; }
        public Method Method {  get; private set; }
        public Pagamento Pagamento { get; private set; }

        //Valor total em centavos dos juros pagos.
        //Total value in cents of interest paid.
        public decimal? Interest { get; private set; }

        //Valor total em centavos pagas em multa.
        //Total value in cents of the fine paid.
        public decimal? Fine { get;private set; }
    }
}
