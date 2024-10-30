using GYMFeeManagement.DTOs.Request;
using GYMFeeManagement.Entities;
using GYMFeeManagement.IRepositories;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;

namespace GYMFeeManagement.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly string _ConnectionStrings;

        public RequestRepository(string connectionStrings)
        {
            _ConnectionStrings = connectionStrings;
        }

        public async Task<PaymentRequestDTO> AddPaymentRequest(PaymentRequestDTO request)
        {
            try
            {
                using (var connection = new SqliteConnection(_ConnectionStrings))
                {
                    string insertQuery = @"INSERT INTO Requests (RequestId,RequestType,MemberId,PaymentType,Amount,ReceiptNumber,PaidDate,DueDate,Status,ProgramId,FirstName,LastName,Phone,NIC,UserName,DOB,Gender,Address,EmergencyContactName,EmergencyContactNumber) 
                                   VALUES (@RequestId,@RequestType,@MemberId,@PaymentType,@Amount,@ReceiptNumber,@PaidDate,@DueDate,@Status,@ProgramId,@FirstName,@LastName,@Phone,@NIC,@UserName,@DOB,@Gender,@Address,@EmergencyContactName,@EmergencyContactNumber);";
                    connection.Open();
                    using (var command = new SqliteCommand(insertQuery, connection))
                    {
                        // Handling all parameters and potential null values
                        command.Parameters.AddWithValue("@RequestId", request.RequestId);
                        command.Parameters.AddWithValue("@RequestType", request.RequestType);
                        command.Parameters.AddWithValue("@MemberId", request.MemberId ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@PaymentType", request.PaymentType ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Amount", request.Amount);
                        command.Parameters.AddWithValue("@ReceiptNumber", request.ReceiptNumber ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@PaidDate", request.PaidDate == DateTime.MinValue ? (object)DBNull.Value : request.PaidDate);
                        command.Parameters.AddWithValue("@DueDate", request.DueDate == DateTime.MinValue ? (object)DBNull.Value : request.DueDate);
                        command.Parameters.AddWithValue("@Status", request.Status);


                        command.Parameters.AddWithValue("@ProgramId", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@FirstName", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@LastName", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Phone", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@NIC", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@UserName", (object)DBNull.Value);


                        command.Parameters.AddWithValue("@DOB", (object)DBNull.Value);

                        command.Parameters.AddWithValue("@Gender", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Address", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@EmergencyContactName", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@EmergencyContactNumber", (object)DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                    return request;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LeaveProgramRequestDTO> AddleaveProgramRequest(LeaveProgramRequestDTO request)
        {
            try
            {
                using (var connection = new SqliteConnection(_ConnectionStrings))
                {
                    string insertQuery = @"INSERT INTO Requests (RequestId,RequestType,MemberId,PaymentType,Amount,ReceiptNumber,PaidDate,DueDate,Status,ProgramId,FirstName,LastName,Phone,NIC,UserName,DOB,Gender,Address,EmergencyContactName,EmergencyContactNumber) 
                                   VALUES (@RequestId,@RequestType,@MemberId,@PaymentType,@Amount,@ReceiptNumber,@PaidDate,@DueDate,@Status,@ProgramId,@FirstName,@LastName,@Phone,@NIC,@UserName,@DOB,@Gender,@Address,@EmergencyContactName,@EmergencyContactNumber);";
                    connection.Open();
                    using (var command = new SqliteCommand(insertQuery, connection))
                    {
                        // Handling all parameters and potential null values
                        command.Parameters.AddWithValue("@RequestId", request.RequestId);
                        command.Parameters.AddWithValue("@RequestType", request.RequestType);
                        command.Parameters.AddWithValue("@MemberId", request.MemberId ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Status", request.Status);
                        command.Parameters.AddWithValue("@ProgramId", request.ProgramId ?? (object)DBNull.Value);

                        // Handle null or invalid dates properly
                        command.Parameters.AddWithValue("@PaymentType", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Amount", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@ReceiptNumber", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@PaidDate", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@DueDate", (object)DBNull.Value);

                        command.Parameters.AddWithValue("@FirstName", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@LastName", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Phone", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@NIC", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@UserName", (object)DBNull.Value);

                        // Handle nullable DOB
                        command.Parameters.AddWithValue("@DOB", (object)DBNull.Value);

                        command.Parameters.AddWithValue("@Gender", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Address", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@EmergencyContactName", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@EmergencyContactNumber", (object)DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                    return request;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AddProgramRequestDTO> AddprogramAddon(AddProgramRequestDTO request)
        {
            try
            {
                using (var connection = new SqliteConnection(_ConnectionStrings))
                {
                    string insertQuery = @"INSERT INTO Requests (RequestId,RequestType,MemberId,PaymentType,Amount,ReceiptNumber,PaidDate,DueDate,Status,ProgramId,FirstName,LastName,Phone,NIC,UserName,DOB,Gender,Address,EmergencyContactName,EmergencyContactNumber) 
                                   VALUES (@RequestId,@RequestType,@MemberId,@PaymentType,@Amount,@ReceiptNumber,@PaidDate,@DueDate,@Status,@ProgramId,@FirstName,@LastName,@Phone,@NIC,@UserName,@DOB,@Gender,@Address,@EmergencyContactName,@EmergencyContactNumber);";
                    connection.Open();
                    using (var command = new SqliteCommand(insertQuery, connection))
                    {
                        // Handling all parameters and potential null values
                        command.Parameters.AddWithValue("@RequestId", request.RequestId);
                        command.Parameters.AddWithValue("@RequestType", request.RequestType);
                        command.Parameters.AddWithValue("@MemberId", request.MemberId ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@PaymentType", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Amount", request.Amount);
                        command.Parameters.AddWithValue("@PaidDate", request.PaidDate == DateTime.MinValue ? (object)DBNull.Value : request.PaidDate);
                        command.Parameters.AddWithValue("@DueDate", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@ReceiptNumber", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@ProgramId", request.ProgramId ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Status", request.Status);
                        // Handle null or invalid dates properly


                        command.Parameters.AddWithValue("@FirstName", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@LastName", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Phone", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@NIC", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@UserName", (object)DBNull.Value);

                        // Handle nullable DOB
                        command.Parameters.AddWithValue("@DOB", (object)DBNull.Value);

                        command.Parameters.AddWithValue("@Gender", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Address", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@EmergencyContactName", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@EmergencyContactNumber", (object)DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                    return request;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MemberInfoChangeRequestDTO> AddChangeMemberInfo(MemberInfoChangeRequestDTO request)
        {
            try
            {
                using (var connection = new SqliteConnection(_ConnectionStrings))
                {
                    string insertQuery = @"INSERT INTO Requests (RequestId,RequestType,MemberId,PaymentType,Amount,ReceiptNumber,PaidDate,DueDate,Status,ProgramId,FirstName,LastName,Phone,NIC,UserName,DOB,Gender,Address,EmergencyContactName,EmergencyContactNumber) 
                                   VALUES (@RequestId,@RequestType,@MemberId,@PaymentType,@Amount,@ReceiptNumber,@PaidDate,@DueDate,@Status,@ProgramId,@FirstName,@LastName,@Phone,@NIC,@UserName,@DOB,@Gender,@Address,@EmergencyContactName,@EmergencyContactNumber);";
                    connection.Open();
                    using (var command = new SqliteCommand(insertQuery, connection))
                    {




                        // Handling all parameters and potential null values
                        command.Parameters.AddWithValue("@RequestId", request.RequestId);
                        command.Parameters.AddWithValue("@RequestType", request.RequestType);
                        command.Parameters.AddWithValue("@MemberId", request.MemberId ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@FirstName", request.FirstName ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@LastName", request.LastName ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Phone", request.Phone ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Address", request.Address ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@EmergencyContactName", request.EmergencyContactName ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@EmergencyContactNumber", request.EmergencyContactNumber ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@NIC", request.NIC ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Status", request.Status);
                        // Handle null or invalid dates properly

                        command.Parameters.AddWithValue("@PaymentType", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Amount", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@PaidDate", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@DueDate", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@ReceiptNumber", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@ProgramId", (object)DBNull.Value);

                        command.Parameters.AddWithValue("@UserName", (object)DBNull.Value);

                        // Handle nullable DOB
                        command.Parameters.AddWithValue("@DOB", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Gender", (object)DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                    return request;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<NewMemberRequestDTO> AddNewMemberRequest(NewMemberRequestDTO request)
        {
            try
            {
                using (var connection = new SqliteConnection(_ConnectionStrings))
                {
                    string insertQuery = @"INSERT INTO Requests (RequestId,RequestType,MemberId,PaymentType,Amount,ReceiptNumber,Password, PaidDate,DueDate,Status,ProgramId,FirstName,LastName,Phone,NIC,UserName,DOB,Gender,Address,EmergencyContactName,EmergencyContactNumber) 
                                   VALUES (@RequestId,@RequestType,@MemberId,@PaymentType,@Amount,@ReceiptNumber, @Password, @PaidDate,@DueDate,@Status,@ProgramId,@FirstName,@LastName,@Phone,@NIC,@UserName,@DOB,@Gender,@Address,@EmergencyContactName,@EmergencyContactNumber);";
                    connection.Open();
                    using (var command = new SqliteCommand(insertQuery, connection))
                    {
                        // Handling all parameters and potential null values
                        command.Parameters.AddWithValue("@RequestId", request.RequestId);
                        command.Parameters.AddWithValue("@RequestType", request.RequestType);
                        command.Parameters.AddWithValue("@FirstName", request.FirstName ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@LastName", request.LastName ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@UserName", request.UserName ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@NIC", request.NIC ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Phone", request.Phone ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@DOB", request.DOB == DateTime.MinValue ? (object)DBNull.Value : request.DOB);
                        command.Parameters.AddWithValue("@Gender", request.Gender ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Address", request.Address ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@EmergencyContactName", request.EmergencyContactName ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@EmergencyContactNumber", request.EmergencyContactNumber ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@ReceiptNumber", request.ReceiptNumber ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Password", request.Password ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@PaidDate", request.PaidDate == DateTime.MinValue ? (object)DBNull.Value : request.DOB);
                        command.Parameters.AddWithValue("@Status", request.Status);

                        // Handle null or invalid dates properly
                        command.Parameters.AddWithValue("@MemberId", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@PaymentType", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Amount", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@DueDate", (object)DBNull.Value);

                        command.Parameters.AddWithValue("@ProgramId", (object)DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                    return request;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public async Task<ICollection<Request>> GetAllRequest()
        {
            var requestList = new List<Request>();
            using (var connection = new SqliteConnection(_ConnectionStrings))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Requests";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var request = new Request()
                        {
                            RequestId = reader.IsDBNull(0) ? string.Empty : reader.GetString(0),
                            RequestType = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                            MemberId = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                            PaymentType = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                            Amount = reader.IsDBNull(4) ? 0 : reader.GetDecimal(4),
                            ReceiptNumber = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                            PaidDate = reader.IsDBNull(6) ? (DateTime?)null : (DateTime?)reader.GetDateTime(6),
                            DueDate = reader.IsDBNull(7) ? (DateTime?)null : (DateTime?)reader.GetDateTime(7),
                            Status = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                            ProgramId = reader.IsDBNull(9) ? string.Empty : reader.GetString(9),
                            FirstName = reader.IsDBNull(10) ? string.Empty : reader.GetString(10),
                            LastName = reader.IsDBNull(11) ? string.Empty : reader.GetString(11),
                            Phone = reader.IsDBNull(12) ? string.Empty : reader.GetString(12),
                            NIC = reader.IsDBNull(13) ? string.Empty : reader.GetString(13),
                            UserName = reader.IsDBNull(14) ? string.Empty : reader.GetString(14),
                            DOB = reader.IsDBNull(15) ? (DateTime?)null : (DateTime?)reader.GetDateTime(15),
                            Gender = reader.IsDBNull(16) ? string.Empty : reader.GetString(16),
                            Address = reader.IsDBNull(17) ? string.Empty : reader.GetString(17),
                            EmergencyContactName = reader.IsDBNull(18) ? string.Empty : reader.GetString(18),
                            EmergencyContactNumber = reader.IsDBNull(19) ? string.Empty : reader.GetString(19),
                            Password = reader.IsDBNull(20) ? string.Empty : reader.GetString(20)
                        };
                        requestList.Add(request);
                    }
                }
            }

            return requestList;
        }

        public async Task<Request> GetRequestById(string RequestId)
        {
            using (var connection = new SqliteConnection(_ConnectionStrings))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Requests WHERE RequestId=@RequestId";
                command.Parameters.AddWithValue("@RequestId", RequestId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Request()
                        {
                            RequestId = reader.IsDBNull(0) ? string.Empty : reader.GetString(0),
                            RequestType = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                            MemberId = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                            PaymentType = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                            Amount = reader.IsDBNull(4) ? 0 : reader.GetDecimal(4),
                            ReceiptNumber = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                            PaidDate = reader.IsDBNull(6) ? (DateTime?)null : (DateTime?)reader.GetDateTime(6),
                            DueDate = reader.IsDBNull(7) ? (DateTime?)null : (DateTime?)reader.GetDateTime(7),
                            Status = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                            ProgramId = reader.IsDBNull(9) ? string.Empty : reader.GetString(9),
                            FirstName = reader.IsDBNull(10) ? string.Empty : reader.GetString(10),
                            LastName = reader.IsDBNull(11) ? string.Empty : reader.GetString(11),
                            Phone = reader.IsDBNull(12) ? string.Empty : reader.GetString(12),
                            NIC = reader.IsDBNull(13) ? string.Empty : reader.GetString(13),
                            UserName = reader.IsDBNull(14) ? string.Empty : reader.GetString(14),
                            DOB = reader.IsDBNull(15) ? (DateTime?)null : (DateTime?)reader.GetDateTime(15),
                            Gender = reader.IsDBNull(16) ? string.Empty : reader.GetString(16),
                            Address = reader.IsDBNull(17) ? string.Empty : reader.GetString(17),
                            EmergencyContactName = reader.IsDBNull(18) ? string.Empty : reader.GetString(18),
                            EmergencyContactNumber = reader.IsDBNull(19) ? string.Empty : reader.GetString(19),
                            Password = reader.IsDBNull(20) ? string.Empty : reader.GetString(20)
                        };
                    }
                    else
                    {
                        throw new Exception("Approval Not Found");
                    }
                };
            };

        }

        public async Task<Request> UpdateRequest(string RequestId, Request updateRequest)
        {
            var request = GetRequestById(RequestId);
            if (request != null)
            {
                using (var connection = new SqliteConnection(_ConnectionStrings))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "UPDATE Requests SET RequestType=@RequestType, MemberId=@MemberId, PaymentType=@PaymentType, Amount=@Amount, ReceiptNumber=@ReceiptNumber, PaidDate=@PaidDate, DueDate=@DueDate, Status=@Status, ProgramId=@ProgramId, FirstName= @FirstName, LastName= @LastName, Phone= @Phone, NIC= @NIC , UserName = @UserName, DOB= @DOB, Gender =@Gender, Address= @Address, EmergencyContactName= @EmergencyContactName, EmergencyContactNumber= @EmergencyContactNumber WHERE RequestId =@RequestId";

                    command.Parameters.AddWithValue("@RequestType", updateRequest.RequestType);
                    command.Parameters.AddWithValue("@Status", updateRequest.Status);
                    command.Parameters.AddWithValue("@RequestId", RequestId);

                    command.Parameters.AddWithValue("@Amount", updateRequest.Amount == 0 ? (object)DBNull.Value : updateRequest.Amount);
                    command.Parameters.AddWithValue("@DOB", updateRequest.DOB.HasValue && updateRequest.DOB != DateTime.MinValue ? (object)updateRequest.DOB.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@DueDate", updateRequest.DueDate.HasValue && updateRequest.DueDate != DateTime.MinValue ? (object)updateRequest.DueDate.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@PaidDate", updateRequest.PaidDate.HasValue && updateRequest.PaidDate != DateTime.MinValue ? (object)updateRequest.PaidDate.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@MemberId", string.IsNullOrEmpty(updateRequest.MemberId) ? (object)DBNull.Value : updateRequest.MemberId);
                    command.Parameters.AddWithValue("@PaymentType", string.IsNullOrEmpty(updateRequest.PaymentType) ? (object)DBNull.Value : updateRequest.PaymentType);
                    command.Parameters.AddWithValue("@ReceiptNumber", string.IsNullOrEmpty(updateRequest.ReceiptNumber) ? (object)DBNull.Value : updateRequest.ReceiptNumber);
                    command.Parameters.AddWithValue("@ProgramId", string.IsNullOrEmpty(updateRequest.ProgramId) ? (object)DBNull.Value : updateRequest.ProgramId);
                    command.Parameters.AddWithValue("@FirstName", string.IsNullOrEmpty(updateRequest.FirstName) ? (object)DBNull.Value : updateRequest.FirstName);
                    command.Parameters.AddWithValue("@LastName", string.IsNullOrEmpty(updateRequest.LastName) ? (object)DBNull.Value : updateRequest.LastName);
                    command.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(updateRequest.Phone) ? (object)DBNull.Value : updateRequest.Phone);
                    command.Parameters.AddWithValue("@NIC", string.IsNullOrEmpty(updateRequest.NIC) ? (object)DBNull.Value : updateRequest.NIC);
                    command.Parameters.AddWithValue("@UserName", string.IsNullOrEmpty(updateRequest.UserName) ? (object)DBNull.Value : updateRequest.UserName);
                    command.Parameters.AddWithValue("@Gender", string.IsNullOrEmpty(updateRequest.Gender) ? (object)DBNull.Value : updateRequest.Gender);
                    command.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(updateRequest.Address) ? (object)DBNull.Value : updateRequest.Address);
                    command.Parameters.AddWithValue("@EmergencyContactName", string.IsNullOrEmpty(updateRequest.EmergencyContactName) ? (object)DBNull.Value : updateRequest.EmergencyContactName);
                    command.Parameters.AddWithValue("@EmergencyContactNumber", string.IsNullOrEmpty(updateRequest.EmergencyContactNumber) ? (object)DBNull.Value : updateRequest.EmergencyContactNumber);
                    command.Parameters.AddWithValue("@Password", string.IsNullOrEmpty(updateRequest.Password) ? (object)DBNull.Value : updateRequest.Password);

                    command.ExecuteNonQuery();
                    return updateRequest;
                }
            }
            else
            {
                throw new Exception("Approval Not Found");
            }
        }

        public async Task DeleteRequest(string RequestId)
        {

            using (var connection = new SqliteConnection(_ConnectionStrings))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Requests WHERE RequestId=@RequestId";
                command.Parameters.AddWithValue("@RequestId", RequestId);
                command.ExecuteNonQuery();
            }

        }
    }
}
