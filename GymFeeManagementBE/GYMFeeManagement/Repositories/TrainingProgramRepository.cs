using GYMFeeManagement.Entities;
using GYMFeeManagement.IRepositories;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;

namespace GYMFeeManagement.Repositories
{
    public class TrainingProgramRepository : ITrainigProgramRepository
    {
        private readonly string _ConnectionStrings;

        public TrainingProgramRepository(string connectionStrings)
        {
            _ConnectionStrings = connectionStrings;
        }

        public async Task<TrainingProgram> AddTrainingProgram(TrainingProgram trainingProgram)
        {
            using (var connection = new SqliteConnection(_ConnectionStrings))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command = connection.CreateCommand();
                command.CommandText = "INSERT INTO TrainingPrograms (ProgramId,TypeId, ProgramName, Cost) VALUES (@programId, @typeId, @programName, @cost);";
                command.Parameters.AddWithValue("@programId", trainingProgram.ProgramId);
                command.Parameters.AddWithValue("@typeId", trainingProgram.TypeId);
                command.Parameters.AddWithValue("@programName", trainingProgram.ProgramName);
                command.Parameters.AddWithValue("@cost", trainingProgram.Cost);
                command.ExecuteNonQuery();
            }
            return trainingProgram;
        }

        public async Task<ICollection<TrainingProgram>> GetAllTrainingPrograms()
        {
            var TrainingProgramsList = new List<TrainingProgram>();
            using (var connection = new SqliteConnection(_ConnectionStrings))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM TrainingPrograms";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var trainingProgram = new TrainingProgram()
                        {
                            ProgramId = reader.GetString(0),
                            TypeId = reader.GetString(1),
                            ProgramName = reader.GetString(2),
                            Cost = reader.GetInt32(3),
                        };
                        TrainingProgramsList.Add(trainingProgram);
                    }
                }
            }
            return TrainingProgramsList;
        }

        public async Task<TrainingProgram> GetTrainingProgramByID(string ProgramId)
        {
            using (var connection = new SqliteConnection(_ConnectionStrings))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM TrainingPrograms WHERE ProgramId=@programId";
                command.Parameters.AddWithValue("@programId", ProgramId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new TrainingProgram()
                        {
                            ProgramId = reader.GetString(0),
                            TypeId = reader.GetString(1),
                            ProgramName = reader.GetString(2),
                            Cost = reader.GetInt32(3),
                        };
                    }
                    else
                    {
                        throw new Exception("TrainingProgram Not Found");
                    }
                };
            };
        }

        public async Task<TrainingProgram> UpdateTrainingProgram(string ProgramId, TrainingProgram updateTrainingProgram)
        {
            var findedTrainingProgram = await GetTrainingProgramByID(ProgramId);
            if (findedTrainingProgram != null)
            {
                using (var connection = new SqliteConnection(_ConnectionStrings))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "UPDATE TrainingPrograms SET TypeId=@typeId, ProgramName=@programName, Cost=@cost WHERE ProgramId =@programId";

                    command.Parameters.AddWithValue("@typeId", updateTrainingProgram.TypeId);
                    command.Parameters.AddWithValue("@programName", updateTrainingProgram.ProgramName);
                    command.Parameters.AddWithValue("@cost", updateTrainingProgram.Cost);


                    command.Parameters.AddWithValue("@programId", ProgramId);
                    command.ExecuteNonQuery();
                    return updateTrainingProgram;
                }
            }
            else
            {
                throw new Exception("TrainingProgram Not Found");
            }
        }
        public async Task DeleteTrainingProgram(string ProgramId)
        {
            var findedTrainingProgram = await GetTrainingProgramByID(ProgramId);
            if (findedTrainingProgram != null)
            {
                using (var connection = new SqliteConnection(_ConnectionStrings))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM TrainingPrograms WHERE ProgramId=@programId";
                    command.Parameters.AddWithValue("@programId", ProgramId);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                throw new Exception("TrainingProgram Not Found");
            }
        }
    }
}
