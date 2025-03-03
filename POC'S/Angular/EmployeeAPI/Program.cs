using Microsoft.EntityFrameworkCore; // Required for UseCosmos
using EmployeeAPI.Models;
using EmployeeAPI.Repositories;
using static EmployeeAPI.Repositories.RolesRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EmployeeDbContext>(options =>
    options.UseCosmos(builder.Configuration["CosmosDBConnectionString"],
    databaseName: "Employee"));

builder.Services.AddControllers();

builder.Services.AddTransient<IRolesRepository, RoleRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// In Program.cs or Startup.cs (if using .NET 6 or later)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Apply the CORS policy
var app = builder.Build();
app.UseCors("AllowAllOrigins");

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
