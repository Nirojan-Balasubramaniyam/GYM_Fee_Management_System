using GYMFeeManagement.DTOs.Request;
using GYMFeeManagement.Entities;

namespace GYMFeeManagement.IRepositories
{
    public interface IRequestRepository
    {
        Task<PaymentRequestDTO> AddPaymentRequest(PaymentRequestDTO request);
        Task<LeaveProgramRequestDTO> AddleaveProgramRequest(LeaveProgramRequestDTO request);
        Task<AddProgramRequestDTO> AddprogramAddon(AddProgramRequestDTO request);
        Task<MemberInfoChangeRequestDTO> AddChangeMemberInfo(MemberInfoChangeRequestDTO request);
        Task<NewMemberRequestDTO> AddNewMemberRequest(NewMemberRequestDTO request);
        Task<ICollection<Request>> GetAllRequest();
        Task<Request> GetRequestById(string RequestId);
        Task<Request> UpdateRequest(string RequestId, Request updateRequest);
        Task DeleteRequest(string RequestId);


    }
}
