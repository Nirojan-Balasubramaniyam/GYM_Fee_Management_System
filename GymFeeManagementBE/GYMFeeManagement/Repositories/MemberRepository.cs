using GYMFeeManagement.Entities;
using GYMFeeManagement.IRepositories;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;

namespace GYMFeeManagement.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly string _ConnectionStrings;

        public MemberRepository(string connectionStrings)
        {
            _ConnectionStrings = connectionStrings;
        }

        public async Task<Member> AddMember(Member member)
        {
            try
            {
                using (var connection = new SqliteConnection(_ConnectionStrings))
                {
                    string insertQuery = @"INSERT INTO Members(MemberId,FirstName,LastName,UserName,Password,NIC,Phone,DoB,Gender,Address,EmergencyContact,EmergencyContactPrsn,UserRoll,ImagePath) 
                                            VALUES (@memberId,@firstName,@lastName,@userName,@password,@nIC,@phone,@doB,@gender,@address,@emergencyContact,@emergencyContactPrsn,@userRoll,@imagePath);";
                    connection.Open();
                    using (var command = new SqliteCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@memberId", member.MemberId);
                        command.Parameters.AddWithValue("@firstName", member.FirstName);
                        command.Parameters.AddWithValue("@lastName", member.LastName);
                        command.Parameters.AddWithValue("@userName", member.UserName);
                        command.Parameters.AddWithValue("@password", member.Password);
                        command.Parameters.AddWithValue("@nIC", member.NIC);
                        command.Parameters.AddWithValue("@phone", member.Phone);
                        command.Parameters.AddWithValue("@doB", member.DoB);
                        command.Parameters.AddWithValue("@gender", member.Gender);
                        command.Parameters.AddWithValue("@address", member.Address);
                        command.Parameters.AddWithValue("@emergencyContact", member.EmergencyContactName);
                        command.Parameters.AddWithValue("@emergencyContactPrsn", member.EmergencyContactNumber);
                        command.Parameters.AddWithValue("@userRoll", member.UserRoll);
                        command.Parameters.AddWithValue("@imagePath", (object)member.ImagePath ?? DBNull.Value);
                        command.ExecuteNonQuery();

                    }
                    return member;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ICollection<Member>> GetAllMembers()
        {
            var memberList = new List<Member>();
            using (var connection = new SqliteConnection(_ConnectionStrings))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Members";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var member = new Member()
                        {
                            MemberId = reader.GetString(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            UserName = reader.GetString(3),
                            Password = reader.GetString(4),
                            NIC = reader.GetString(5),
                            Phone = reader.GetString(6),
                            DoB = reader.GetDateTime(7),
                            Gender = reader.GetString(8),
                            Address = reader.GetString(9),
                            EmergencyContactName = reader.GetString(10),
                            EmergencyContactNumber = reader.GetString(11),
                            UserRoll = reader.GetString(12),
                            ImagePath = reader.IsDBNull(13) ? "/profileimages/f250c506-5cf5-4dfc-9740-0dc8f2117893.jpg.jpg" : reader.GetString(13),
                            // ImagePath = reader.GetString(13) == "" ? "/profileimages/f250c506 - 5cf5 - 4dfc - 9740 - 0dc8f2117893.jpg" : reader.GetString(13),
                        };
                        memberList.Add(member);
                    }
                }
            }

            return memberList;
        }

        public async Task<Member> GetMemberById(string MemberId)
        {
            using (var connection = new SqliteConnection(_ConnectionStrings))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Members WHERE MemberId=@memberId";
                command.Parameters.AddWithValue("@memberId", MemberId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Member()
                        {
                            MemberId = reader.GetString(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            UserName = reader.GetString(3),
                            Password = reader.GetString(4),
                            NIC = reader.GetString(5),
                            Phone = reader.GetString(6),
                            DoB = reader.GetDateTime(7),
                            Gender = reader.GetString(8),
                            Address = reader.GetString(9),
                            EmergencyContactName = reader.GetString(10),
                            EmergencyContactNumber = reader.GetString(11),
                            UserRoll = reader.GetString(12),
                            ImagePath = reader.IsDBNull(13) ? "/profileimages/f250c506-5cf5-4dfc-9740-0dc8f2117893.jpg.jpg" : reader.GetString(13),

                        };
                    }
                    else
                    {
                        throw new Exception("Member Not Found");
                    }
                };
            };
        }

        public async Task<Member> UpdateMember(string MemberId, Member updateMember)
        {
            var findedMember = await GetMemberById(MemberId);
            if (findedMember != null)
            {
                using (var connection = new SqliteConnection(_ConnectionStrings))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "UPDATE Members SET FirstName=@firstName, LastName=@lastName, UserName=@userName, Password=@password, NIC=@nIC, Phone=@phone, DoB=@doB, Gender=@gender, Address=@address, EmergencyContact=@emergencyContact, EmergencyContactPrsn=@emergencyContactPrsn, UserRoll=@userRoll, ImagePath=@imagePath WHERE MemberId =@memberId";

                    command.Parameters.AddWithValue("@firstName", updateMember.FirstName);
                    command.Parameters.AddWithValue("@lastName", updateMember.LastName);
                    command.Parameters.AddWithValue("@userName", updateMember.UserName);
                    command.Parameters.AddWithValue("@password", updateMember.Password);
                    command.Parameters.AddWithValue("@nIC", updateMember.NIC);
                    command.Parameters.AddWithValue("@phone", updateMember.Phone);
                    command.Parameters.AddWithValue("@doB", updateMember.DoB);
                    command.Parameters.AddWithValue("@gender", updateMember.Gender);
                    command.Parameters.AddWithValue("@address", updateMember.Address);
                    command.Parameters.AddWithValue("@emergencyContact", updateMember.EmergencyContactName);
                    command.Parameters.AddWithValue("@emergencyContactPrsn", updateMember.EmergencyContactNumber);
                    command.Parameters.AddWithValue("@userRoll", updateMember.UserRoll);
                    command.Parameters.AddWithValue("@imagePath", updateMember.ImagePath == null ? "" : updateMember.ImagePath);
                    command.Parameters.AddWithValue("@memberId", MemberId);
                    command.ExecuteNonQuery();
                    return updateMember;
                }
            }
            else
            {
                throw new Exception("Member Not Found");
            }
        }

        public async Task UpdateProfilePic(string memberId, string ImagePath)
        {
            var findedMember = GetMemberById(memberId);
            if (findedMember != null)
            {
                using (var connection = new SqliteConnection(_ConnectionStrings))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "UPDATE Members SET ImagePath = @imagepath  WHERE MemberId = @memberId";
                    command.Parameters.AddWithValue("@imagepath", ImagePath == null ? "" : ImagePath);
                    command.Parameters.AddWithValue("@memberId", memberId);
                    var RowEffected = command.ExecuteNonQuery();
                    if (RowEffected <= 0)
                    {
                        throw new Exception("Member Not Found..");
                    }
                }
            }
            else
            {
                throw new Exception("Member Not Found!");
            }
        }
        public async Task DeleteMember(string MemberId)
        {
            var findedMember = await GetMemberById(MemberId);
            if (findedMember != null)
            {
                using (var connection = new SqliteConnection(_ConnectionStrings))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM Members WHERE MemberId=@memberId";
                    command.Parameters.AddWithValue("@memberId", MemberId);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                throw new Exception("Member Not Found");
            }
        }
    }
}
