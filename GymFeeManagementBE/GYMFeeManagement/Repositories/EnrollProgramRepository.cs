using GYMFeeManagement.Entities;
using GYMFeeManagement.IRepositories;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;

namespace GYMFeeManagement.Repositories
{
    public class EnrollProgramRepository: IEnrollProgramRepository
    {
        private readonly string _ConnectionStrings;

        public EnrollProgramRepository(string connectionStrings)
        {
            _ConnectionStrings = connectionStrings;
        }

        public async Task<EnrollProgram> AddEnrollProgram(EnrollProgram enrolledTrainingPrograms)
        {
            try
            {
                using (var connection = new SqliteConnection(_ConnectionStrings))
                {
                    string insertQuery = @"INSERT INTO EnrollPrograms(EnrollId,ProgramId, MemberId) 
                                           VALUES (@enrollProgramId,@programId,@memberId);";
                    connection.Open();
                    using (var command = new SqliteCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@enrollProgramId", enrolledTrainingPrograms.EnrollId);
                        command.Parameters.AddWithValue("@programId", enrolledTrainingPrograms.ProgramId);
                        command.Parameters.AddWithValue("@memberId", enrolledTrainingPrograms.MemberId);
                        command.ExecuteNonQuery();

                    }
                    return enrolledTrainingPrograms;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<ICollection<EnrollProgram>> GetAllEnrollProgram()
        {
            var enrollProgramList = new List<EnrollProgram>();
            using (var connection = new SqliteConnection(_ConnectionStrings))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM EnrollPrograms";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var EnrolledTrainingProgram = new EnrollProgram()
                        {
                            EnrollId = reader.GetString(0),
                            ProgramId = reader.GetString(1),
                            MemberId = reader.GetString(2),
                        };
                        enrollProgramList.Add(EnrolledTrainingProgram);
                    }
                }
            }
            return enrollProgramList;
        }

        public async Task<EnrollProgram> GetEnrollProgramById(string EnrollId)
        {
            using (var connection = new SqliteConnection(_ConnectionStrings))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM EnrollPrograms WHERE EnrollId=@enrollId";
                command.Parameters.AddWithValue("@enrollId", EnrollId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new EnrollProgram()
                        {
                            EnrollId = reader.GetString(0),
                            ProgramId = reader.GetString(1),
                            MemberId = reader.GetString(2),
                        };

                    }
                    else
                    {
                        throw new Exception("Enroll Program Not Found");
                    }
                };
            };
        }

        public async Task<EnrollProgram> UpdateEnrollProgram(string EnrollId, EnrollProgram updateEnrollProgram)
        {
            var findedEnrollProgram = await GetEnrollProgramById(EnrollId);
            if (findedEnrollProgram != null)
            {
                using (var connection = new SqliteConnection(_ConnectionStrings))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "UPDATE EnrollPrograms SET ProgramId=@programId, MemberId=@memberId WHERE EnrollId =@enrollId";

                    command.Parameters.AddWithValue("@programId", updateEnrollProgram.ProgramId);
                    command.Parameters.AddWithValue("@memberId", updateEnrollProgram.MemberId);

                    command.Parameters.AddWithValue("@enrollId", EnrollId);
                    command.ExecuteNonQuery();
                    return updateEnrollProgram;
                }
            }
            else
            {
                throw new Exception("Enroll Program Not Found");
            }
        }
        public async Task DeleteEnrollProgram(string EnrollId)
        {
            var findedEnrollProgram = await GetEnrollProgramById(EnrollId);
            if (findedEnrollProgram != null)
            {
                using (var connection = new SqliteConnection(_ConnectionStrings))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM EnrollPrograms WHERE EnrollId =@enrollId";
                    command.Parameters.AddWithValue("@enrollId", EnrollId);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                throw new Exception("EnrollProgram Not Found");
            }
        }
    }
}
