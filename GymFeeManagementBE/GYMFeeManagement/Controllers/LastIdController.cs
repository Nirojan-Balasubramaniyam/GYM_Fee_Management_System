using GYMFeeManagement.Entities;
using GYMFeeManagement.IRepositories;
using GYMFeeManagement.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace GYMFeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LastIdController : ControllerBase
    {
        private readonly ILastIdRepository _lastIdRepository;

        public LastIdController(ILastIdRepository lastIdRepository)
        {
            _lastIdRepository = lastIdRepository;
        }

        [HttpPost()]

        public async Task<IActionResult> AddLastId(LastId newLastId)
        {
            try
            {
                var LastIdData = await _lastIdRepository.AddLastId(newLastId);
                return Ok(LastIdData);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet()]
        public async Task<IActionResult> GetAllLastIds()
        {
            try
            {
                var LastIdList = await _lastIdRepository.GetLastIdById(1);
                return Ok(LastIdList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut()]

        public async Task<IActionResult> UpdateLastId(LastId updateLastId)
        {
            try
            {
                var updatedLastId = await _lastIdRepository.UpdateLastId(updateLastId);
                return Ok(updatedLastId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]

        public async Task<IActionResult> DeleteLastId(int Id)
        {
            try
            {
                await _lastIdRepository.DeleteLastId(Id);
                return Ok("LastId Deleted Successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
