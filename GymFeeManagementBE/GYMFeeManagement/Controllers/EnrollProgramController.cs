using GYMFeeManagement.Entities;
using GYMFeeManagement.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GYMFeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollProgramController : ControllerBase
    {
        private readonly IEnrollProgramRepository _enrolledPrograms;

        public EnrollProgramController(IEnrollProgramRepository enrolledPrograms)
        {
            _enrolledPrograms = enrolledPrograms;
        }

        [HttpPost()]

        public async Task<IActionResult> AddEnrollProgram(EnrollProgram enrolledTrainingPrograms)
        {
            try
            {
                var addedEnrolled = _enrolledPrograms.AddEnrollProgram(enrolledTrainingPrograms);
                return Ok(addedEnrolled);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet()]
        public async Task<IActionResult> GetAllEnrollPrograms()
        {
            try
            {
                var EnrolledTrainingProgramList = await _enrolledPrograms.GetAllEnrollProgram();
                return Ok(EnrolledTrainingProgramList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{EnrollProgramId}")]
        public async Task<IActionResult> GetEnrollProgramById(string EnrollId)
        {
            try
            {
                var Payment = await _enrolledPrograms.GetEnrollProgramById(EnrollId);
                return Ok(Payment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{EnrollId}")]
        public async Task<IActionResult> UpdateEnrollProgram(string EnrollId, EnrollProgram updateEnrollProgram)
        {
            try
            {
                var updatedEntollPeogram = await _enrolledPrograms.UpdateEnrollProgram(EnrollId, updateEnrollProgram);
                return Ok(updatedEntollPeogram);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{EnrollId}")]

        public async Task<IActionResult> DeleteEnrollProgram(string EnrollId)
        {
            try
            {
                await _enrolledPrograms.DeleteEnrollProgram(EnrollId);
                return Ok("EnrolledProgram Deleted Successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
