using GYMFeeManagement.Entities;
using GYMFeeManagement.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GYMFeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainigProgramController : ControllerBase
    {
        private readonly ITrainigProgramRepository _trainingProgramRepository;

        public TrainigProgramController(ITrainigProgramRepository trainingProgramActivitiesRepository)
        {
            _trainingProgramRepository = trainingProgramActivitiesRepository;
        }

        [HttpPost()]
        public async Task<IActionResult> AddTrainingProgram(TrainingProgram trainingProgram)
        {
            try
            {
                var TrainingProgramActivitiesData = await _trainingProgramRepository.AddTrainingProgram(trainingProgram);
                return Ok(TrainingProgramActivitiesData);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllTrainingPrograms()
        {
            try
            {
                var TrainingProgramsList = await _trainingProgramRepository.GetAllTrainingPrograms();
                return Ok(TrainingProgramsList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{ProgramId}")]
        public async Task<IActionResult> GetTrainingProgramByID(string ProgramId)
        {
            try
            {
                var findedTrainingProgram = await _trainingProgramRepository.GetTrainingProgramByID(ProgramId);
                return Ok(findedTrainingProgram);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{ProgramId}")]
        public async Task<IActionResult> UpdateTrainingProgram(string ProgramId, TrainingProgram updateTrainingProgram)
        {
            try
            {
                var UpdatedTrainingProgram = await _trainingProgramRepository.UpdateTrainingProgram(ProgramId, updateTrainingProgram);
                return Ok(UpdatedTrainingProgram);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{ProgramId}")]

        public async Task<IActionResult> DeleteTrainingProgram(string ProgramId)
        {
            try
            {
                await _trainingProgramRepository.DeleteTrainingProgram(ProgramId);
                return Ok("Training Program Deleted Successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
