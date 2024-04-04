using CloudSuite.Domain.Enums;
using NetDevPack.Domain;

namespace CloudSuite.Domain.Models.Cora_Context
{
    public class Transaction: Entity, IAggregateRoot
    {
        public Transaction(
            decimal? entryAmount,
            TransactionTypeEnum transactionTypeEnum,
            DateTimeOffset? entryCreatedAt,
            string? entryTransactionDescription,
            string? entryTranscationCounterPartyName,
            string? transactionOnOrder,
            string? entryTransactionCounterPartyIdentity
            )
        {
            TransactionTypeEnum = transactionTypeEnum;
            EntryAmount = entryAmount;
            EntryCreatedAt = entryCreatedAt;
            EntryTransactionDescription = entryTransactionDescription;
            EntryTranscationCounterPartyName = entryTranscationCounterPartyName;
            TransactionOnOrder = transactionOnOrder;
            EntryTransactionCounterPartyIdentity = entryTransactionCounterPartyIdentity;
        }

        public TransactionTypeEnum TransactionTypeEnum { get; private set; }
        public decimal? EntryAmount { get; private set; }
        public DateTimeOffset? EntryCreatedAt { get; private set; }
        public string? EntryTransactionDescription {  get; private set; }
        public string? EntryTranscationCounterPartyName {  get; private set; }
        public string? TransactionOnOrder {  get; private set; }
        public string? EntryTransactionCounterPartyIdentity {  get; private set; }
    }
}
