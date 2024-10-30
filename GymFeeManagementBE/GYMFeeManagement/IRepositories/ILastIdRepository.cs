using GYMFeeManagement.Entities;

namespace GYMFeeManagement.IRepositories
{
    public interface ILastIdRepository
    {

        Task<LastId> AddLastId(LastId lastid);
        Task<ICollection<LastId>> GetAllLastIds();
        Task<LastId> GetLastIdById(int Id);
        Task<LastId> UpdateLastId(LastId updateLastId);
        Task DeleteLastId(int Id);
    }
}
