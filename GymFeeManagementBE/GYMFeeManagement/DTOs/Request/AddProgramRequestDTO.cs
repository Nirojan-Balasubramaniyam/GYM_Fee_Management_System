namespace GYMFeeManagement.DTOs.Request
{
    public class AddProgramRequestDTO
    {
        public string RequestId { get; set; }
        public string RequestType { get; set; }
        public string MemberId { get; set; }
        public string ProgramId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaidDate { get; set; }
        public string ReceiptNumber { get; set; }
        public string Status { get; set; }
    }
}
