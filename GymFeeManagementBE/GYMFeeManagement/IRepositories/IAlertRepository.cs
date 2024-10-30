using GYMFeeManagement.DTOs.Request;
using GYMFeeManagement.Entities;

namespace GYMFeeManagement.IRepositories
{
    public interface IAlertRepository
    {
        Task<AlertDTO> AddOverdueRenewalAlert(AlertDTO alert);
        Task<Alert> AddRequestAlert(Alert alert);
        Task<ICollection<Alert>> GetAllALerts();
        Task<Alert> GetAlertById(string AlertId);
        Task<Alert> UpdateAlert(string AlertId, Alert updateAlert);
        Task DeleteAlert(string AlertId);
    }
}
