using EmployeeService.Commands;
using EmployeeService.Models;
using EmployeeService.Queries;
using EmployeeService.Repositories;
using EmployeeService.Validators.EmployeeValidators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Extensions
{
    public static class RegisterCustomServicesExtension
    {
        public static void RegisterCustomServices(this IServiceCollection services,  WebApplicationBuilder builder)
        {
            var conf = builder.Configuration;

            services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<GetEmployeeValidator>();

            string connectionString = conf.GetConnectionString("DefaultConnection");
            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));
            }
            else
            {
                builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            }

            builder.Services.AddScoped<IEmployeeCommandsRepository, EmployeeCommandsRepository>();
            builder.Services.AddScoped<IEmployeeQueriesRepository, EmployeeQueriesRepository>();
            builder.Services.AddScoped<IDepartmentCommandsRepository, DepartmentCommandsRepository>();
            builder.Services.AddScoped<IDepartmentQueriesRepository, DepartmentQueriesRepository>();
            builder.Services.AddScoped<IPositionQueriesRepository, PositionQueriesRepository>();
            builder.Services.AddScoped<IPositionCommandsRepository, PositionCommandsRepository>();

            builder.Services.AddScoped<IDepartmentQueries, DepartmentQueries>();
            builder.Services.AddScoped<IEmployeeQueries, EmployeeQueries>();
            builder.Services.AddScoped<IPositionQueries, PositionQueries>();
            builder.Services.AddScoped<IDepartmentCommands, DepartmentCommands>();
            builder.Services.AddScoped<IEmployeeCommands, EmployeeCommands>();
            builder.Services.AddScoped<IPositionCommands, PositionCommands>();
        }
    }
}
