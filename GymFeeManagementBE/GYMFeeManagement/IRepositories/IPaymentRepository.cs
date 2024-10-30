using GYMFeeManagement.Entities;

namespace GYMFeeManagement.IRepositories
{
    public interface IPaymentRepository
    {
        Task<Payment> AddPayment(Payment payment);
        Task<ICollection<Payment>> GetAllPayments();
        Task<Payment> GetPaymentById(string PaymentId);
        Task<Payment> UpdatePayment(string PaymentId, Payment updatePayment);
        Task DeletePayment(string PaymentId);
    }
}
