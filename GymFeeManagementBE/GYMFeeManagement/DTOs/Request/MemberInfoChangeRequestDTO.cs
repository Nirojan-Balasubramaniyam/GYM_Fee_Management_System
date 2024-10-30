namespace GYMFeeManagement.DTOs.Request
{
    public class MemberInfoChangeRequestDTO
    {
        public string RequestId { get; set; }
        public string RequestType { get; set; }
        public string MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string NIC { get; set; }
        public DateTime DoB { get; set; }
        public string Address { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactNumber { get; set; }
        public string Status { get; set; }
    }
}
