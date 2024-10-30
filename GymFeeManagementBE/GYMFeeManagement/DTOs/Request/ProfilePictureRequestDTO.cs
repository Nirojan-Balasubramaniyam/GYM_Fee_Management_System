namespace GYMFeeManagement.DTOs.Request
{
    public class ProfilePictureRequestDTO
    {
        public string MemberId { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
