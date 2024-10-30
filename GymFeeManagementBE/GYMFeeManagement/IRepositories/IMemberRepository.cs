using GYMFeeManagement.Entities;

namespace GYMFeeManagement.IRepositories
{
    public interface IMemberRepository
    {
        Task<Member> AddMember(Member member);
        Task<ICollection<Member>> GetAllMembers();
        Task<Member> GetMemberById(string MemberId);
        Task<Member> UpdateMember(string MemberId, Member updateMember);
        Task UpdateProfilePic(string memberId, string ImagePath);
        Task DeleteMember(string MemberId);

    }
}
