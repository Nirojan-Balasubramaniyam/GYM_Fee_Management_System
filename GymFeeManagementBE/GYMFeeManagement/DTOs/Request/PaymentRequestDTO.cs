namespace GYMFeeManagement.DTOs.Request
{
    public class PaymentRequestDTO
    {
        public string RequestId { get; set; }
        public string RequestType { get; set; }
        public string MemberId { get; set; }
        public string PaymentType { get; set; }
        public decimal Amount { get; set; }
        public string ReceiptNumber { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
    }
}
