using CloudSuite.Domain.ValueObjects;
using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Models.Cora_Context.Payments
{
    public class PaymentHistory : Entity, IAggregateRoot
    {
        public string? StatusPayment {  get; private set; }
        public DateTime? StartDateQuery {  get; private set; }
        public DateTime? EndDateQuery {  get; private set; }
        public Pagination Pagination {  get; private set; }
        public Pagamento Pagamento {  get; private set; }

        public PaymentHistory(string? statusPayment, DateTime? startDateQuery, DateTime? endDateQuery)
        {
            StatusPayment = statusPayment;
            StartDateQuery = startDateQuery;
            EndDateQuery = endDateQuery;
        }
    }
}
