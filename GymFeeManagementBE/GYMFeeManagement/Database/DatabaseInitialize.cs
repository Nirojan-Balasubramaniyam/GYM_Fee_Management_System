using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;

namespace GYMFeeManagement.Database
{
    public class DatabaseInitialize
    {
        private readonly string _ConnectionStrings;
        //private readonly string _masterConnectionStrings = "Data Source=Gym_ManagementSystem.db;Version=3;";


        public DatabaseInitialize(string connectionStrings)
        {
            _ConnectionStrings = connectionStrings;
        }
        public void Initialize()
        {
          /*  using (var connection = new SqliteConnection(_masterConnectionStrings))
            {
                string dbQuery = @"
                        IF NOT EXISTS (SELECT * FROM sys.databases WHERE name='Gym_ManagementSystem')
                        CREATE DATABASE Gym_ManagementSystem;";
                connection.Open();
                using (var command = new SqliteCommand(dbQuery, connection))
                {
                    command.ExecuteNonQuery();

                }
            }*/
            using (var connection = new SqliteConnection(_ConnectionStrings))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"

                            CREATE TABLE IF NOT EXISTS Members(
                            MemberId NVARCHAR(50) NOT NULL PRIMARY KEY,
                            FirstName NVARCHAR(50) NOT NULL,
                            LastName  NVARCHAR(50) NOT NULL,
                            UserName  NVARCHAR(50) NOT NULL,
                            Password NVARCHAR(50) NOT NULL,
                            NIC  NVARCHAR(50) NOT NULL,
                            Phone NVARCHAR(50) NOT NULL,
                            DOB DATE NOT NULL,
                            Gender  NVARCHAR(50) NOT NULL,
                            Address  NVARCHAR(50) NOT NULL,
                            EmergencyContact  NVARCHAR(50) NOT NULL,
                            EmergencyContactPrsn  NVARCHAR(50) NOT NULL,
                            UserRoll NVARCHAR(50) NOT NULL,
                            ImagePath NVARCHAR(100) NULL
                        );

                        
                        CREATE TABLE IF NOT EXISTS ProgramTypes(
                            TypeId NVARCHAR(50) NOT NULL PRIMARY KEY,
                            TypeName NVARCHAR(50) NOT NULL
                        );

                        
                        CREATE TABLE IF NOT EXISTS TrainingPrograms(
                            ProgramId NVARCHAR(50) NOT NULL PRIMARY KEY,
                            TypeId NVARCHAR(50) NOT NULL,
                            ProgramName NVARCHAR(50) NOT NULL,
                            Cost INT NOT NULL,
                            FOREIGN KEY (TypeId) REFERENCES ProgramTypes(TypeId) ON DELETE CASCADE
                        );  

                        
                       CREATE TABLE IF NOT EXISTS Payments(
                            PaymentId NVARCHAR(50) NOT NULL PRIMARY KEY,
                            MemberId NVARCHAR(50) NOT NULL,
                            PaymentType NVARCHAR(50) NOT NULL,
                            Amount INT NOT NULL,
                            PaymentMethod NVARCHAR(50) NOT NULL,
                            PaidDate DATE NOT NULL,
                            DueDate DATE NULL,
                            FOREIGN KEY (MemberId) REFERENCES Members(MemberId) ON DELETE CASCADE
                        );

                      
                        CREATE TABLE IF NOT EXISTS EnrollPrograms(
                            EnrollId NVARCHAR(50) NOT NULL PRIMARY KEY,
                            ProgramId NVARCHAR(50) NOT NULL,
                            MemberId  NVARCHAR(50) NOT NULL,
                            FOREIGN KEY (MemberId) REFERENCES Members(MemberId) ON DELETE CASCADE,
                            FOREIGN KEY (ProgramId) REFERENCES TrainingPrograms(ProgramId) ON DELETE CASCADE
                        );

                  
                        CREATE TABLE IF NOT EXISTS Alerts(
                            AlertId NVARCHAR(50) NOT NULL PRIMARY KEY,
                            AlertType NVARCHAR(50) NOT NULL,
                            Amount INT NULL,
                            ProgramId  NVARCHAR(50) NULL,
                            DueDate  DATE NULL,
                            MemberId  NVARCHAR(50) NOT NULL,
                            Status  BOOLEAN NOT NULL,
                            Action BOOLEAN NOT NULL,
                            AccessedDate DATE NULL
                        );

                     
                        CREATE TABLE IF NOT EXISTS Requests(
                            RequestId NVARCHAR(50) NOT NULL PRIMARY KEY,
                            RequestType NVARCHAR(50) NOT NULL,
                            MemberId NVARCHAR(50) NULL,
                            PaymentType  NVARCHAR(50) NULL,
                            Amount  INT NULL,
                            ReceiptNumber  NVARCHAR(50) NULL,
                            PaidDate DATETIME NULL,
                            DueDate DATETIME NULL,                
                            Status NVARCHAR(50)  NULL,  
                            ProgramId NVARCHAR(50) NULL,  
                            FirstName NVARCHAR(50) NULL,  
                            LastName NVARCHAR(50) NULL,  
                            Phone NVARCHAR(50) NULL,  
                            NIC NVARCHAR(50) NULL,  
                            UserName NVARCHAR(50) NULL,  
                            DOB DATETIME NULL,
                            Gender NVARCHAR(50) NULL,  
                            Address NVARCHAR(50) NULL,  
                            EmergencyContactName NVARCHAR(50) NULL, 
                            EmergencyContactNumber NVARCHAR(50) NULL,
                            Password NVARCHAR(50) NULL 
           
                        );

                    
                        CREATE TABLE IF NOT EXISTS LastIds(
                            Id INT NOT NULL PRIMARY KEY,
                            MemberId INT NOT NULL,
                            AlertId INT  NOT NULL,
                            EnrollId  INT  NOT NULL,
                            PaymentId  INT  NOT NULL,
                            ProgramId  INT  NOT NULL,
                            RequestId INT  NOT NULL
                         );
                
                            PRAGMA foreign_keys = ON;
                        ";

                command.ExecuteNonQuery();
            }
        }
    }
}
