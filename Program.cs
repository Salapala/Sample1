using Microsoft.EntityFrameworkCore;
using HospitalManagementApi.Infrastructure;
using HospitalManagementApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<HospitalManagementApi.Infrastructure.HospitalManagementDbContext>
(
    options=>options.UseSqlServer
        (
            connectionString: "server=(local);database=HospitalManagementDb;integrated security=sspi"
        )
);

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
