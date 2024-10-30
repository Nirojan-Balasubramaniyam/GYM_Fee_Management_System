using GYMFeeManagement.DTOs.Request;
using GYMFeeManagement.Entities;
using GYMFeeManagement.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GYMFeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MemberController(IMemberRepository memberRepository, IWebHostEnvironment webHostEnvironment)
        {
            _memberRepository = memberRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost()]
        public async Task<IActionResult> AddMember(MemberDTO addMember)
        {
            try
            {
                // Check model state validity and log specific errors if invalid
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return BadRequest($"Model binding errors: {string.Join(", ", errors)}");
                }

                // Manual parsing for DoB if necessary
                DateTime dob;
                if (!DateTime.TryParse(addMember.DoB.ToString(), out dob))
                {
                    return BadRequest("Invalid date format for Date of Birth");
                }

                var newMember = new Member
                {
                    MemberId = addMember.MemberId,
                    FirstName = addMember.FirstName,
                    LastName = addMember.LastName,
                    UserName = addMember.UserName,
                    Password = addMember.Password,
                    NIC = addMember.NIC,
                    Phone = addMember.Phone,
                    DoB = dob,
                    Gender = addMember.Gender,
                    Address = addMember.Address,
                    EmergencyContactName = addMember.EmergencyContactName,
                    EmergencyContactNumber = addMember.EmergencyContactNumber,
                    UserRoll = addMember.UserRoll,
                    ImagePath = null // Set null if ImageFile is missing
                };

                // Image file handling (only if ImageFile exists)
                if (addMember.ImageFile != null && addMember.ImageFile.Length > 0)
                {
                    var profileimagesPath = Path.Combine(_webHostEnvironment.WebRootPath, "profileimages");

                    if (!Directory.Exists(profileimagesPath))
                    {
                        Directory.CreateDirectory(profileimagesPath);
                    }

                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(addMember.ImageFile.FileName);
                    var imagePath = Path.Combine(profileimagesPath, fileName);

                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        await addMember.ImageFile.CopyToAsync(stream);
                    }

                    newMember.ImagePath = "/profileimages/" + fileName;
                }

                var memberData = await _memberRepository.AddMember(newMember);
                return Ok(memberData);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }


        [HttpPost("request-member")]
        public async Task<IActionResult> AddRequestMember(MemberRegisterDTO addMember)
        {
            try
            {
                // Check model state validity and log specific errors if invalid
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return BadRequest($"Model binding errors: {string.Join(", ", errors)}");
                }

                // Manual parsing for DoB if necessary
                DateTime dob;
                if (!DateTime.TryParse(addMember.DoB.ToString(), out dob))
                {
                    return BadRequest("Invalid date format for Date of Birth");
                }

                var newMember = new Member
                {
                    MemberId = addMember.MemberId,
                    FirstName = addMember.FirstName,
                    LastName = addMember.LastName,
                    UserName = addMember.UserName,
                    Password = addMember.Password,
                    NIC = addMember.NIC,
                    Phone = addMember.Phone,
                    DoB = dob,
                    Gender = addMember.Gender,
                    Address = addMember.Address,
                    EmergencyContactName = addMember.EmergencyContactName,
                    EmergencyContactNumber = addMember.EmergencyContactNumber,
                    UserRoll = addMember.UserRoll,
                    ImagePath = null
                };



                var memberData = await _memberRepository.AddMember(newMember);
                return Ok(memberData);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllMembers()
        {
            try
            {
                var memberList = await _memberRepository.GetAllMembers();
                return Ok(memberList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{MemberId}")]
        public async Task<IActionResult> GetMemberById(string MemberId)
        {
            try
            {
                var member = await _memberRepository.GetMemberById(MemberId);
                return Ok(member);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{MemberId}")]
        public async Task<IActionResult> UpdateMember(string MemberId, Member updateMember)
        {
            try
            {
                var updatedMember = await _memberRepository.UpdateMember(MemberId, updateMember);
                return Ok(updatedMember);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update-Profile-Picture")]

        public async Task<IActionResult> UpdateProfilePic(ProfilePictureRequestDTO profileRequest)
        {
            try
            {
                var ImagePath = "";

                if (profileRequest.ImageFile != null && profileRequest.ImageFile.Length > 0)
                {

                    if (string.IsNullOrEmpty(_webHostEnvironment.WebRootPath))
                    {
                        throw new ArgumentNullException(nameof(_webHostEnvironment.WebRootPath), "WebRootPath is not set. Make sure the environment is configured properly.");
                    }

                    var profileimagesPath = Path.Combine(_webHostEnvironment.WebRootPath, "profileimages");


                    if (!Directory.Exists(profileimagesPath))
                    {
                        Directory.CreateDirectory(profileimagesPath);
                    }

                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(profileRequest.ImageFile.FileName);
                    var imagePath = Path.Combine(profileimagesPath, fileName);

                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        await profileRequest.ImageFile.CopyToAsync(stream);
                    }


                    ImagePath = "/profileimages/" + fileName;
                }
                else
                {
                    ImagePath = null;
                }


                await _memberRepository.UpdateProfilePic(profileRequest.MemberId, ImagePath);
                return Ok("Profile Pic Updated..");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{MemberId}")]
        public async Task<IActionResult> DeleteMember(string MemberId)
        {
            try
            {
                await _memberRepository.DeleteMember(MemberId);
                return Ok("Member Deleted Successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
