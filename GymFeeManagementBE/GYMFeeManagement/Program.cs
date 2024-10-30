
using GYMFeeManagement.Database;
using GYMFeeManagement.IRepositories;
using GYMFeeManagement.Repositories;
using SQLitePCL;

namespace GYMFeeManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.WebHost.UseWebRoot("wwwroot");

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            Batteries.Init();

            var connectionStrings = builder.Configuration.GetConnectionString("DbConnection");

            builder.Services.AddSingleton<IAlertRepository>(provider => new AlertRepository(connectionStrings));
            builder.Services.AddSingleton<IEnrollProgramRepository>(provider => new EnrollProgramRepository(connectionStrings));
            builder.Services.AddSingleton<IMemberRepository>(provider => new MemberRepository(connectionStrings));
            builder.Services.AddSingleton<ILastIdRepository>(provider => new LastIdRepository(connectionStrings));

            builder.Services.AddSingleton<IPaymentRepository>(provider => new PaymentRepository(connectionStrings));

            builder.Services.AddSingleton<IProgramTypeRepository>(provider => new ProgramTypeRepository(connectionStrings));

            builder.Services.AddSingleton<IRequestRepository>(provider => new RequestRepository(connectionStrings));

            builder.Services.AddSingleton<ITrainigProgramRepository>(provider => new TrainingProgramRepository(connectionStrings));





            var Initialize = new DatabaseInitialize(connectionStrings);
            Initialize.Initialize();
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors();

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
