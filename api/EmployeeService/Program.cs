using EmployeeService.Models;
using EmployeeService.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterCustomServices(builder);

var clientHost = builder.Configuration.GetValue<string>("ClientHostname") ?? "localhost:3000";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyAllowSpecificOrigins",
                        policy =>
                        {
                            policy.WithOrigins($"http://{clientHost}")
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                        });
});

var app = builder.Build();

app.UseCors("MyAllowSpecificOrigins");

app.UseSwagger();

app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

InitializeDb.Migrate(app);

app.Run();
