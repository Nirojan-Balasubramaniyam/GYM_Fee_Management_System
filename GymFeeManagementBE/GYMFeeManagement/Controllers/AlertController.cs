using GYMFeeManagement.DTOs.Request;
using GYMFeeManagement.Entities;
using GYMFeeManagement.IRepositories;
using GYMFeeManagement.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GYMFeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertController : ControllerBase
    {
        private readonly IAlertRepository _alertRepository;

        public AlertController(IAlertRepository alertRepository)
        {
            _alertRepository = alertRepository;
        }

        [HttpPost()]

        public async Task<IActionResult> AddAlert(AlertDTO alert)
        {
            try
            {
                var AlertData = await _alertRepository.AddOverdueRenewalAlert(alert);
                return Ok(AlertData);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("request-alert")]

        public async Task<IActionResult> AddRequestAlert(Alert alert)
        {
            try
            {
                var AlertData = await _alertRepository.AddRequestAlert(alert);
                return Ok(AlertData);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet()]
        public async Task<IActionResult> GetAllAlerts()
        {
            try
            {
                var AlertList = await _alertRepository.GetAllALerts();
                return Ok(AlertList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{AlertId}")]
        public async Task<IActionResult> GetAlertById(string AlertId)
        {
            try
            {
                var alert = await _alertRepository.GetAlertById(AlertId);
                return Ok(alert);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{AlertId}")]

        public async Task<IActionResult> UpdateAlert(string AlertId, Alert updateAlert)
        {
            try
            {
                var updatealert = await _alertRepository.UpdateAlert(AlertId, updateAlert);
                return Ok(updatealert);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{AlertId}")]

        public async Task<IActionResult> DeleteAlert(string AlertId)
        {
            try
            {
                await _alertRepository.DeleteAlert(AlertId);
                return Ok("Alert Deleted Successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
