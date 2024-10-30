using GYMFeeManagement.DTOs.Request;
using GYMFeeManagement.Entities;
using GYMFeeManagement.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GYMFeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestRepository _requestRepository;

        public RequestController(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        [HttpPost("PaymentRequest")]

        public async Task<IActionResult> AddPaymentRequest(PaymentRequestDTO paymentRequestDTO)
        {
            try
            {
                var requestData = await _requestRepository.AddPaymentRequest(paymentRequestDTO);
                return Ok(requestData);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("LeaveProgramRequest")]

        public async Task<IActionResult> AddleaveProgramRequest(LeaveProgramRequestDTO leaveProgramRequestDTO)
        {
            try
            {
                var requestData = await _requestRepository.AddleaveProgramRequest(leaveProgramRequestDTO);
                return Ok(requestData);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost("ProgramAddon")]

        public async Task<IActionResult> AddprogramAddon(AddProgramRequestDTO programAddonRequestDTO)
        {
            try
            {
                var requestData = await _requestRepository.AddprogramAddon(programAddonRequestDTO);
                return Ok(requestData);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost("ChangeMemberInfo")]

        public IActionResult AddChangeMemberInfo(MemberInfoChangeRequestDTO changeMemberInfoDTO)
        {
            try
            {
                var approvalData = _requestRepository.AddChangeMemberInfo(changeMemberInfoDTO);
                return Ok(approvalData);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("NewMemberRequest")]

        public async Task<IActionResult> AddNewMemberRequest(NewMemberRequestDTO newMemberRequestDTO)
        {
            try
            {
                var approvalData = _requestRepository.AddNewMemberRequest(newMemberRequestDTO);
                return Ok(approvalData);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet()]
        public async Task<IActionResult> GetAllRequest()
        {
            try
            {
                var approvalList = await _requestRepository.GetAllRequest();
                return Ok(approvalList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{RequestId}")]
        public async Task<IActionResult> UpdateRequest(string RequestId, Request updateRequestDTO)
        {
            try
            {
                var updatedRequest = await _requestRepository.UpdateRequest(RequestId, updateRequestDTO);
                return Ok(updatedRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{RequestId}")]

        public async Task<IActionResult> DeleteRequest(string RequestId)
        {
            try
            {
                await _requestRepository.DeleteRequest(RequestId);
                return Ok("Request Deleted Successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
