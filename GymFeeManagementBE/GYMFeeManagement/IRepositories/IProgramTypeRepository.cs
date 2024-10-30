using GYMFeeManagement.Entities;

namespace GYMFeeManagement.IRepositories
{
    public interface IProgramTypeRepository
    {
        Task<ProgramType> AddProgramType(ProgramType ProgramType);
        Task<ICollection<ProgramType>> GetAllProgramTypes();
        Task<ProgramType> GetAllProgramTypeById(string TypeId);
        Task DeleteProgramType(string TypeId);
    }
}
