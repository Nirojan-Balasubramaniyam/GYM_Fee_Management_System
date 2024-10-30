namespace GYMFeeManagement.Entities
{
    public class Alert
    {
        public string AlertId { get; set; }
        public string AlertType { get; set; }
        public decimal? Amount { get; set; }
        public string? ProgramId { get; set; }
        public DateTime? DueDate { get; set; }
        public string MemberId { get; set; }
        public bool Status { get; set; }
        public bool Action { get; set; }
        public DateTime? AccessedDate { get; set; }
    }
}
