using GYMFeeManagement.DTOs.Request;
using GYMFeeManagement.Entities;

namespace GYMFeeManagement.IRepositories
{
    public interface ITrainigProgramRepository
    {
        Task<TrainingProgram> AddTrainingProgram(TrainingProgram trainingProgram);
        Task<ICollection<TrainingProgram>> GetAllTrainingPrograms();
        Task<TrainingProgram> GetTrainingProgramByID(string ProgramId);
        Task<TrainingProgram> UpdateTrainingProgram(string ProgramId, TrainingProgram updateTrainingProgram);
        Task DeleteTrainingProgram(string ProgramId);

    }
}
