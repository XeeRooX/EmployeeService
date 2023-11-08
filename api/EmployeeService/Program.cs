using EmployeeService.Models;
using EmployeeService.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));

builder.Services.AddScoped<IEmployeeCommandsRepository, EmployeeCommandsRepository>();
builder.Services.AddScoped<IEmployeeQueriesRepository, EmployeeQueriesRepository>();
builder.Services.AddScoped<IDepartmentCommandsRepository, DepartmentCommandsRepository>();
builder.Services.AddScoped<IDepartmentQueriesRepository, DepartmentQueriesRepository>();
builder.Services.AddScoped<IPositionQueriesRepository, PositionQueriesRepository>();
builder.Services.AddScoped<IPositionCommandsRepository, PositionCommandsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
