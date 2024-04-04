using CloudSuite.Domain.Enums;
using CloudSuite.Domain.Models.Cora_Context.Payments;
using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CloudSuite.Domain.Models.Cora_Context
{
    public class Extract: Entity, IAggregateRoot
    {

        private List<Transaction> _transactions;


        public Extract(DateTimeOffset startDate, decimal? startBalance, DateTimeOffset? endDate)
        {
            StartBalance = startBalance;
            EndDate = endDate;
            StartDate = startDate;
        }

        public Extract(decimal? entryAmount, decimal? endBalance, DateTimeOffset? endDate,
            decimal? startBalance, DateTimeOffset startDate, string? headerBusinessDocument,
            string? headerBusinessName)
        {
            EntryAmount = entryAmount;
            EndBalance = endBalance;
            EndDate = endDate;
            StartBalance = startBalance;
            StartDate = startDate;
            HeaderBusinessDocument = headerBusinessDocument;
            HeaderBusinessName = headerBusinessName;
        }

        public Extract(List<Transaction> transactions,
            DateTimeOffset startDate,
            decimal? startBalance,
            DateTimeOffset? endDate,
            decimal? endBalance,
            Customer customer,
            Transaction transaction, OperationTypeEnum entryType,
            decimal? aggregationsCreditTotal,
            decimal? aggregationsDebitTotal,
            decimal? entryAmount, string? headerBusiness,
            string? headerBusinessDocument
            )
        {
            _transactions = transactions;
            StartDate = startDate;
            StartBalance = startBalance;
            EndDate = endDate;
            EndBalance = endBalance;
            Customer = customer;
            Transaction = transaction;
            EntryType = entryType;
            AggregationsCreditTotal = aggregationsCreditTotal;
            AggregationsDebitTotal = aggregationsDebitTotal;
            EntryAmount = entryAmount;
            HeaderBusinessDocument = headerBusinessDocument;
        }

        public DateTimeOffset StartDate {  get; private set; }

        public decimal? StartBalance { get; private set; }

        public DateTimeOffset? EndDate {  get; private set; }

        public decimal? EndBalance { get; private set; }

        public Customer Customer {  get; private set; }

        public OperationTypeEnum EntryType {  get; private set; }

        public Transaction Transaction { get; private set; }

        public decimal? AggregationsCreditTotal {  get; private set; }

        public decimal? AggregationsDebitTotal {  get; private set; }

        public decimal? EntryAmount {  get; private set; }

        public string? HeaderBusinessName {  get; private set; }

        public string? HeaderBusinessDocument {  get; private set; }

        public Guid TransactionId {  get; private set; }

        public IReadOnlyCollection<Transaction> Transactions { get { return _transactions.ToArray(); } }
    }
}
