using GYMFeeManagement.Entities;
using GYMFeeManagement.IRepositories;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;

namespace GYMFeeManagement.Repositories
{
    public class LastIdRepository : ILastIdRepository
    {
        private readonly string _ConnectionStrings;

        public LastIdRepository(string connectionStrings)
        {
            _ConnectionStrings = connectionStrings;
        }

        public async Task<LastId> AddLastId(LastId lastid)
        {
            try
            {
                using (var connection = new SqliteConnection(_ConnectionStrings))
                {
                    string insertQuery = @"INSERT INTO LastIds (Id,MemberId,AlertId,EnrollId,PaymentId,ProgramId,RequestId) 
                                                VALUES (@Id,@memberId,@alertId,@enrollId,@paymentId,@programId,@requestId);";
                    connection.Open();
                    using (var command = new SqliteCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", lastid.Id);
                        command.Parameters.AddWithValue("@memberId", lastid.MemberId);
                        command.Parameters.AddWithValue("@alertId", lastid.AlertId);
                        command.Parameters.AddWithValue("@enrollId", lastid.EnrollId);
                        command.Parameters.AddWithValue("@paymentId", lastid.PaymentId);
                        command.Parameters.AddWithValue("@programId", lastid.ProgramId);
                        command.Parameters.AddWithValue("@requestId", lastid.RequestId);

                        command.ExecuteNonQuery();

                    }
                    return lastid;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<ICollection<LastId>> GetAllLastIds()
        {
            var LastIdList = new List<LastId>();
            using (var connection = new SqliteConnection(_ConnectionStrings))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM LastIds";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var Lastid = new LastId()
                        {
                            Id = reader.GetInt32(0),
                            MemberId = reader.GetInt32(1),
                            AlertId = reader.GetInt32(2),
                            EnrollId = reader.GetInt32(3),
                            PaymentId = reader.GetInt32(4),
                            ProgramId = reader.GetInt32(5),
                            RequestId = reader.GetInt32(6)
                        };
                        LastIdList.Add(Lastid);
                    }
                }
            }
            return LastIdList;
        }

        public async Task<LastId> GetLastIdById(int Id)
        {
            using (var connection = new SqliteConnection(_ConnectionStrings))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM LastIds WHERE Id=@id";
                command.Parameters.AddWithValue("@id", Id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new LastId()
                        {
                            Id = reader.GetInt32(0),
                            MemberId = reader.GetInt32(1),
                            AlertId = reader.GetInt32(2),
                            EnrollId = reader.GetInt32(3),
                            PaymentId = reader.GetInt32(4),
                            ProgramId = reader.GetInt32(5),
                            RequestId = reader.GetInt32(6)
                        };
                    }
                    else
                    {
                        throw new Exception("LastId Not Found");
                    }
                };
            };
        }

        public async Task<LastId> UpdateLastId(LastId updateLastId)
        {


            using (var connection = new SqliteConnection(_ConnectionStrings))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE LastIds SET MemberId=@memberId, AlertId=@alertId, EnrollId=@enrollProgramId, PaymentId=@paymentId, ProgramId=@programId, RequestId=@requestId WHERE Id =@id";

                command.Parameters.AddWithValue("@memberId", updateLastId.MemberId);
                command.Parameters.AddWithValue("@alertId", updateLastId.AlertId);
                command.Parameters.AddWithValue("@enrollProgramId", updateLastId.EnrollId);
                command.Parameters.AddWithValue("@paymentId", updateLastId.PaymentId);
                command.Parameters.AddWithValue("@programId", updateLastId.ProgramId);
                command.Parameters.AddWithValue("@requestId", updateLastId.RequestId);
                command.Parameters.AddWithValue("@id", 1);
                command.ExecuteNonQuery();
                return updateLastId;
            }

        }


        public async Task DeleteLastId(int Id)
        {
            var SearchlastId = await GetLastIdById(Id);
            if (SearchlastId != null)
            {
                using (var connection = new SqliteConnection(_ConnectionStrings))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM LastIds WHERE Id=@id";
                    command.Parameters.AddWithValue("@id", Id);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                throw new Exception("LastId Not Found");
            }
        }
    }
}
