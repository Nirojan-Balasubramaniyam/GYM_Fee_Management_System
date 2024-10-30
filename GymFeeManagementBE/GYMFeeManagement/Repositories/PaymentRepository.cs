using GYMFeeManagement.Entities;
using GYMFeeManagement.IRepositories;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;

namespace GYMFeeManagement.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly string _ConnectionStrings;

        public PaymentRepository(string connectionStrings)
        {
            _ConnectionStrings = connectionStrings;
        }

        public async Task<Payment> AddPayment(Payment payment)
        {
            try
            {
                using (var connection = new SqliteConnection(_ConnectionStrings))
                {

                    string insertQuery = @"INSERT INTO Payments(PaymentId,MemberId,PaymentType,Amount,PaymentMethod, PaidDate,DueDate) 
                                                VALUES (@paymentId,@memberId,@paymentType,@amount,@paymentMethod, @paidDate,@dueDate);";
                    connection.Open();
                    using (var command = new SqliteCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@paymentId", payment.PaymentId);
                        command.Parameters.AddWithValue("@memberId", payment.MemberId);
                        command.Parameters.AddWithValue("@paymentType", payment.PaymentType);
                        command.Parameters.AddWithValue("@amount", payment.Amount);
                        command.Parameters.AddWithValue("@paymentMethod", payment.PaymentMethod);
                        command.Parameters.AddWithValue("@paidDate", payment.PaidDate);
                        //command.Parameters.AddWithValue("@DueDate", payment.DueDate == DateTime.MinValue ? (object)DBNull.Value : payment.DueDate);
                        if (payment.DueDate.HasValue)
                        {
                            command.Parameters.AddWithValue("@dueDate", payment.DueDate.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@dueDate", DBNull.Value); // Pass DBNull for null DueDate
                        }

                        command.ExecuteNonQuery();
                    }
                    return payment;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ICollection<Payment>> GetAllPayments()
        {
            var paymentList = new List<Payment>();
            using (var connection = new SqliteConnection(_ConnectionStrings))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Payments";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var payments = new Payment()
                        {
                            PaymentId = reader.GetString(0),
                            MemberId = reader.GetString(1),
                            PaymentType = reader.GetString(2),
                            Amount = reader.GetInt32(3),
                            PaymentMethod = reader.GetString(4),
                            PaidDate = reader.GetDateTime(5),
                            DueDate = reader.IsDBNull(6) ? (DateTime?)null : reader.GetDateTime(6)
                        };
                        paymentList.Add(payments);
                    }
                }
            }
            return paymentList;
        }


        public async Task<Payment> GetPaymentById(string PaymentId)
        {
            using (var connection = new SqliteConnection(_ConnectionStrings))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Payments WHERE PaymentId=@paymentId";
                command.Parameters.AddWithValue("@paymentId", PaymentId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Payment()
                        {
                            PaymentId = reader.GetString(0),
                            MemberId = reader.GetString(1),
                            PaymentType = reader.GetString(2),
                            Amount = reader.GetInt32(3),
                            PaymentMethod = reader.GetString(4),
                            PaidDate = reader.GetDateTime(5),
                            DueDate = reader.IsDBNull(6) ? (DateTime?)null : reader.GetDateTime(6)
                        };

                    }
                    else
                    {
                        throw new Exception("Payment Not Found");
                    }
                };
            };
        }

        public async Task<Payment> UpdatePayment(string PaymentId, Payment updatePayment)
        {
            var findedPayment = await GetPaymentById(PaymentId);
            if (findedPayment != null)
            {
                using (var connection = new SqliteConnection(_ConnectionStrings))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "UPDATE Payments SET MemberId=@memberId, PaymentType=@paymentType, Amount=@amount, PaymentMethod=@paymentMethod, PaidDate=@paidDate, DueDate=@dueDate WHERE PaymentId =@paymentId";

                    command.Parameters.AddWithValue("@memberId", updatePayment.MemberId);
                    command.Parameters.AddWithValue("@paymentType", updatePayment.PaymentType);
                    command.Parameters.AddWithValue("@amount", updatePayment.Amount);
                    command.Parameters.AddWithValue("@paymentMethod", updatePayment.PaymentMethod);
                    command.Parameters.AddWithValue("@paidDate", updatePayment.PaidDate);
                    command.Parameters.AddWithValue("@dueDate", updatePayment.DueDate);


                    command.Parameters.AddWithValue("@paymentId", PaymentId);
                    command.ExecuteNonQuery();
                    return updatePayment;
                }
            }
            else
            {
                throw new Exception("Payment Not Found");
            }
        }
        public async Task DeletePayment(string PaymentId)
        {
            var findedPayment = await GetPaymentById(PaymentId);
            if (findedPayment != null)
            {
                using (var connection = new SqliteConnection(_ConnectionStrings))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM Payments WHERE PaymentId=@paymentId";
                    command.Parameters.AddWithValue("@paymentId", PaymentId);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                throw new Exception("Payment Not Found");
            }
        }
    }
}
