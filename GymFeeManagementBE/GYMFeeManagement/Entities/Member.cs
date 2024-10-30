namespace GYMFeeManagement.Entities
{
    public class Member
    {
        public string MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NIC { get; set; }
        public string Phone { get; set; }
        public DateTime DoB { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactNumber { get; set; }
        public string UserRoll { get; set; }
        public string? ImagePath { get; set; }
    }
}
