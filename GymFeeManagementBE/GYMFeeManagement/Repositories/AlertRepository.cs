using GYMFeeManagement.DTOs.Request;
using GYMFeeManagement.Entities;
using GYMFeeManagement.IRepositories;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;

namespace GYMFeeManagement.Repositories
{
    public class AlertRepository : IAlertRepository
    {
        private readonly string _ConnectionStrings;

        public AlertRepository(string connectionStrings)
        {
            _ConnectionStrings = connectionStrings;
        }

        public async Task<AlertDTO> AddOverdueRenewalAlert(AlertDTO alert)
        {
            try
            {
                using (var connection = new SqliteConnection(_ConnectionStrings))
                {
                    string insertQuery = @"
                INSERT INTO Alerts (AlertId, AlertType, Amount, ProgramId, DueDate, MemberId, Status, Action, AccessedDate) 
                VALUES (@alertId, @alertType, @amount, @programId, @dueDate, @memberId, @status, @action, @accessedDate);";

                    connection.Open();
                    using (var command = new SqliteCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@alertId", alert.AlertId);
                        command.Parameters.AddWithValue("@alertType", alert.AlertType);
                        command.Parameters.AddWithValue("@amount", alert.Amount);
                        command.Parameters.AddWithValue("@memberId", alert.MemberId);
                        command.Parameters.AddWithValue("@status", alert.Status);
                        command.Parameters.AddWithValue("@action", true);
                        command.Parameters.AddWithValue("@dueDate", alert.DueDate.HasValue ? (object)alert.DueDate.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@programId", alert.ProgramId ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@accessedDate", DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the alert.", ex);
            }

            return alert;
        }


        public async Task<Alert> AddRequestAlert(Alert alert)
        {
            try
            {
                using (var connection = new SqliteConnection(_ConnectionStrings))
                {
                    string insertQuery = @"
                        INSERT INTO Alerts (AlertId, AlertType, Amount, ProgramId, DueDate, MemberId, Status, Action, AccessedDate) 
                        VALUES (@alertId, @alertType, @amount, @programId, @dueDate, @memberId, @status, @action, @accessedDate);";

                    connection.Open();
                    using (var command = new SqliteCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@alertId", alert.AlertId);
                        command.Parameters.AddWithValue("@alertType", alert.AlertType);
                        command.Parameters.AddWithValue("@amount", alert.Amount);
                        command.Parameters.AddWithValue("@programId", alert.ProgramId ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@memberId", alert.MemberId);
                        command.Parameters.AddWithValue("@status", alert.Status);
                        command.Parameters.AddWithValue("@action", alert.Action);
                        command.Parameters.AddWithValue("@accessedDate", alert.AccessedDate ?? (object)DBNull.Value);
                        if (alert.DueDate.HasValue)
                        {
                            command.Parameters.AddWithValue("@dueDate", alert.DueDate.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@dueDate", DBNull.Value); // Pass DBNull for null DueDate
                        }


                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the alert.", ex);
            }

            return alert;
        }


        public async Task<ICollection<Alert>> GetAllALerts()
        {
            var alertList = new List<Alert>();
            using (var connection = new SqliteConnection(_ConnectionStrings))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Alerts";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var alert = new Alert()
                        {
                            AlertId = reader.GetString(0),
                            AlertType = reader.GetString(1),
                            Amount = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                            ProgramId = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                            DueDate = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4),
                            MemberId = reader.GetString(5),
                            Status = reader.GetBoolean(6),
                            Action = reader.GetBoolean(7),
                            AccessedDate = reader.IsDBNull(8) ? (DateTime?)null : reader.GetDateTime(8)
                        };
                        alertList.Add(alert);
                    }
                }
            }

            return alertList;
        }

        public async Task<Alert> GetAlertById(string AlertId)
        {
            using (var connection = new SqliteConnection(_ConnectionStrings))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Alerts WHERE AlertId=@alertId";
                command.Parameters.AddWithValue("@alertId", AlertId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Alert()
                        {
                            AlertId = reader.GetString(0),
                            AlertType = reader.GetString(1),
                            Amount = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                            ProgramId = reader.GetString(3),
                            DueDate = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4),
                            MemberId = reader.GetString(5),
                            Status = reader.GetBoolean(6),
                            Action = reader.GetBoolean(7),
                            AccessedDate = reader.IsDBNull(8) ? (DateTime?)null : reader.GetDateTime(8)
                        };

                    }
                    else
                    {
                        throw new Exception("Alert Not Found");
                    }
                };
            };
        }

        public async Task<Alert> UpdateAlert(string AlertId, Alert updateAlert)
        {
            var approval = GetAlertById(AlertId);
            if (approval != null)
            {
                using (var connection = new SqliteConnection(_ConnectionStrings))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "UPDATE Alerts SET AlertType=@alertType, Amount=@amount, ProgramId=@programId, DueDate=@dueDate, MemberId=@memberId, Status=@status, Action=@action, AccessedDate=@accessedDate WHERE AlertId =@alertId";

                    command.Parameters.AddWithValue("@alertType", updateAlert.AlertType);
                    command.Parameters.AddWithValue("@programId", string.IsNullOrEmpty(updateAlert.ProgramId) ? (object)DBNull.Value : updateAlert.ProgramId);
                    command.Parameters.AddWithValue("@memberId", string.IsNullOrEmpty(updateAlert.MemberId) ? (object)DBNull.Value : updateAlert.MemberId);
                    command.Parameters.AddWithValue("@status", updateAlert.Status);
                    command.Parameters.AddWithValue("@action", updateAlert.Action);
                    command.Parameters.AddWithValue("@amount", updateAlert.Amount == 0 ? (object)DBNull.Value : updateAlert.Amount);
                    command.Parameters.AddWithValue("@accessedDate", updateAlert.AccessedDate.HasValue && updateAlert.AccessedDate != DateTime.MinValue ? (object)updateAlert.AccessedDate.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@dueDate", updateAlert.DueDate.HasValue && updateAlert.DueDate != DateTime.MinValue ? (object)updateAlert.DueDate.Value : DBNull.Value);


                    command.Parameters.AddWithValue("@alertId", AlertId);
                    command.ExecuteNonQuery();
                    return updateAlert;
                }
            }
            else
            {
                throw new Exception("Alert Not Found");
            }
        }

        public async Task DeleteAlert(string AlertId)
        {
            var SearchAlert = await GetAlertById(AlertId);
            if (SearchAlert != null)
            {
                using (var connection = new SqliteConnection(_ConnectionStrings))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM Alerts WHERE AlertId=@alertId";
                    command.Parameters.AddWithValue("@alertId", AlertId);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                throw new Exception("Alert Not Found");
            }
        }
    }
}
