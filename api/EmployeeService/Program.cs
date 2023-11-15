using EmployeeService.Commands;
using EmployeeService.Models;
using EmployeeService.Queries;
using EmployeeService.Repositories;
using EmployeeService.Validators.EmployeeValidators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using static FluentValidation.DependencyInjectionExtensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddValidatorsFromAssemblyContaining<GetEmployeeValidator>();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));

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

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyAllowSpecificOrigins",
                        policy =>
                        {
                            policy.WithOrigins("http://localhost:3000")
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                        });
});

var app = builder.Build();

app.UseCors("MyAllowSpecificOrigins");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
