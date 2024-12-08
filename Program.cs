
using ClinicSystem.Repository;
using ClinicSystem.Services;
using Microsoft.EntityFrameworkCore;

namespace ClinicSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddDbContext<AppDbcontext>(options =>
                   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            // Add services to the container.
            builder.Services.AddScoped<IbookingSrevices, bookingSrevices>();
            builder.Services.AddScoped<IClinicServices, ClinicServices>();
            builder.Services.AddScoped<IPatientServices, PatientServices>();
            builder.Services.AddScoped<IBookingRepo, BookingRepo>();
            builder.Services.AddScoped<IPatientRepo, PatientRepo>();
            builder.Services.AddScoped<ICliniRepo, CliniRepo>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
