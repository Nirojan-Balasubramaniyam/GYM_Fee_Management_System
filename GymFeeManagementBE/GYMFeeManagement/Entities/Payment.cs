namespace GYMFeeManagement.Entities
{
    public class Payment
    {
        public string PaymentId { get; set; }
        public string MemberId { get; set; }
        public string PaymentType { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
