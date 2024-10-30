using GYMFeeManagement.Entities;
using GYMFeeManagement.IRepositories;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;

namespace GYMFeeManagement.Repositories
{
    public class ProgramTypeRepository : IProgramTypeRepository
    {

            private readonly string _ConnectionStrings;

            public ProgramTypeRepository(string connectionStrings)
            {
                _ConnectionStrings = connectionStrings;
            }

            public async Task<ProgramType> AddProgramType(ProgramType ProgramType)
            {
                try
                {
                    using (var connection = new SqliteConnection(_ConnectionStrings))
                    {
                        string insertQuery = @"INSERT INTO ProgramTypes (TypeId, TypeName) 
                                                VALUES (@typeId,@typeName);";
                        connection.Open();
                        using (var command = new SqliteCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@typeId", ProgramType.TypeId);
                            command.Parameters.AddWithValue("@typeName", ProgramType.TypeName);
                            command.ExecuteNonQuery();

                        }
                        return ProgramType;

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }

            public async Task<ICollection<ProgramType>> GetAllProgramTypes()
            {
                var ProgramTypeList = new List<ProgramType>();
                using (var connection = new SqliteConnection(_ConnectionStrings))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM ProgramTypes";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var ProgramType = new ProgramType()
                            {
                                TypeId = reader.GetString(0),
                                TypeName = reader.GetString(1)
                            };
                            ProgramTypeList.Add(ProgramType);
                        }
                    }
                }
                return ProgramTypeList;
            }

            public async Task<ProgramType> GetAllProgramTypeById(string TypeId)
            {
                using (var connection = new SqliteConnection(_ConnectionStrings))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM ProgramTypes WHERE TypeId=@typeId";
                    command.Parameters.AddWithValue("@typeId", TypeId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ProgramType()
                            {
                                TypeId = reader.GetString(0),
                                TypeName = reader.GetString(1),
                            };

                        }
                        else
                        {
                            throw new Exception("ProgramType Not Found");
                        }
                    };
                };
            }

            public async Task DeleteProgramType(string TypeId)
            {
                var findedProgramType = await GetAllProgramTypeById(TypeId);
                if (findedProgramType != null)
                {
                    using (var connection = new SqliteConnection(_ConnectionStrings))
                    {
                        connection.Open();
                        var command = connection.CreateCommand();
                        command.CommandText = "DELETE FROM ProgramTypes WHERE TypeId=@typeId";
                        command.Parameters.AddWithValue("@typeId", TypeId);
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    throw new Exception("ProgramType Not Found");
                }
            }
        }
}
