
using Microsoft.EntityFrameworkCore;
using ResumeFinder.Domain.Contracts;
using ResumeFinder.Domain.Storage;
using ResumeFinder.Repositories;
using ResumeFinder.Services;
using ResumeFinder.Utils;

namespace ResumeFinder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IWorkerRepository, WorkerRepository>();
            builder.Services.AddScoped<IResumeRepository, ResumeRepository>();
            builder.Services.AddScoped<IWorkPlaceRepository, WorkPlaceRepository>();
            builder.Services.AddScoped<ISpecializationRepository, SpecializationRepository>();

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IWorkerService, WorkerService>();
            builder.Services.AddScoped<IResumeServices, ResumeService>();
            builder.Services.AddScoped<IWorkPlaceService, WorkPlaceService>();
            builder.Services.AddScoped<ISpecializationService, SpecializationService>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

            builder.Services.AddDbContext<ResumeFinderContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL")));

            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
