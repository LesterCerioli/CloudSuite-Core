namespace CloudSuite.Domain.Models.Cora_Context.Payments
{
    public class PaymentScheduling
    {
        public PaymentScheduling(string? digitableLine, DateTime? scheduleAt, string? paymentStatus, string? code, decimal? amount, DateTime? createdAt)
        {
            DigitableLine = digitableLine;
            ScheduleAt = scheduleAt;
            PaymentStatus = paymentStatus;
            Code = code;
            Amount = amount;
            CreatedAt = createdAt;
        }

        public string? DigitableLine {  get; private set; }
        public DateTime? ScheduleAt {  get; private set; }
        public string? PaymentStatus {  get; private set; }
        public string? Code {  get; private set; }
        public decimal? Amount { get; private set; }
        public DateTime? CreatedAt {  get; private set; }
    }
}
