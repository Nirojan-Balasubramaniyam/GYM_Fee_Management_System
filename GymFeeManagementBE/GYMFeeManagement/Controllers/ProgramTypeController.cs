using GYMFeeManagement.Entities;
using GYMFeeManagement.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GYMFeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramTypeController : ControllerBase
    {
        private readonly IProgramTypeRepository _programTypesRepository;

        public ProgramTypeController(IProgramTypeRepository programTypesRepository)
        {
            _programTypesRepository = programTypesRepository;
        }

        [HttpPost()]

        public async Task<IActionResult> AddProgramTypes(ProgramType trainingProgramTypes)
        {
            try
            {
                var PaymentData = await _programTypesRepository.AddProgramType(trainingProgramTypes);
                return Ok(PaymentData);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet()]
        public async Task<IActionResult> GetAllProgramTypes()
        {
            try
            {
                var programTypeList = await _programTypesRepository.GetAllProgramTypes();
                return Ok(programTypeList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{ProgramTypeId}")]
        public async Task<IActionResult> GetProgramTypeById(string TypeId)
        {
            try
            {
                var programType = await _programTypesRepository.GetAllProgramTypeById(TypeId);
                return Ok(programType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{TypeId}")]

        public async Task<IActionResult> DeleteProgramType(string TypeId)
        {
            try
            {
                await _programTypesRepository.DeleteProgramType(TypeId);
                return Ok("ProgramType Deleted Successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
