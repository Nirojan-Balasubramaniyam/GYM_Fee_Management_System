namespace GYMFeeManagement.DTOs.Request
{
    public class NewMemberRequestDTO
    {
        public string RequestId { get; set; }
        public string RequestType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string NIC { get; set; }
        public string UserName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactNumber { get; set; }
        public string ReceiptNumber { get; set; }
        public string Password { get; set; }
        public DateTime PaidDate { get; set; }

        public string Status { get; set; }
    }
}
