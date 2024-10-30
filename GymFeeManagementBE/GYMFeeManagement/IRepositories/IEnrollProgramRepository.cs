using GYMFeeManagement.Entities;

namespace GYMFeeManagement.IRepositories
{
    public interface IEnrollProgramRepository
    {
        Task<EnrollProgram> AddEnrollProgram(EnrollProgram enrolledTrainingPrograms);
        Task<ICollection<EnrollProgram>> GetAllEnrollProgram();
        Task<EnrollProgram> GetEnrollProgramById(string EnrollId);
        Task<EnrollProgram> UpdateEnrollProgram(string EnrollId, EnrollProgram updateEnrollProgram);
        Task DeleteEnrollProgram(string EnrollId);
    }
}
