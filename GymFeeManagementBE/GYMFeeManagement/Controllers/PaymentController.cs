using GYMFeeManagement.Entities;
using GYMFeeManagement.IRepositories;
using GYMFeeManagement.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GYMFeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        [HttpPost()]
        public async Task<IActionResult> AddPayment(Payment newPayment)
        {
            try
            {
                var PaymentData = await _paymentRepository.AddPayment(newPayment);
                return Ok(PaymentData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet()]
        public IActionResult GetAllPayment()
        {
            try
            {
                var PaymentList = _paymentRepository.GetAllPayments();
                return Ok(PaymentList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{PaymentId}")]
        public async Task<IActionResult> GetPaymentById(string PaymentId)
        {
            try
            {
                var Payment = await _paymentRepository.GetPaymentById(PaymentId);
                return Ok(Payment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{PaymentId}")]
        public async Task<IActionResult> UpdatePayment(string PaymentId, Payment updatePayment)
        {
            try
            {
                var updatedPayment = await _paymentRepository.UpdatePayment(PaymentId, updatePayment);
                return Ok(updatedPayment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{PaymentId}")]

        public async Task<IActionResult> DeletePayment(string PaymentId)
        {
            try
            {
                await _paymentRepository.DeletePayment(PaymentId);
                return Ok("Payment Deleted Successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
