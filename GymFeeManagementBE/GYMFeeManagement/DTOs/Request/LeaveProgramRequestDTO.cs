namespace GYMFeeManagement.DTOs.Request
{
    public class LeaveProgramRequestDTO
    {
        public string RequestId { get; set; }
        public string RequestType { get; set; }
        public string MemberId { get; set; }
        public string ProgramId { get; set; }
        public string Status { get; set; }
    }
}
