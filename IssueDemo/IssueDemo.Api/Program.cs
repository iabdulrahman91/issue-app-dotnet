using IssueDemo.Application;
using IssueDemo.Application.Common.Errors;
using IssueDemo.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// move dependency injection to its layer, so each layer manage its own dependencies
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddHealthChecks();

var app = builder.Build();

app.MapHealthChecks("/health");

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment()) // to run swagger in production //TODO: utlize env setting to disable in production
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// add to handle error
app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
