namespace GYMFeeManagement.DTOs.Request
{
    public class AlertDTO
    {
        public string AlertId { get; set; }
        public string AlertType { get; set; }
        public int? Amount { get; set; }
        public string? ProgramId { get; set; }
        public DateTime? DueDate { get; set; }
        public string MemberId { get; set; }
        public bool Status { get; set; }
    }
}
