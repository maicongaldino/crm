using CRM.Api.Exceptions;
using CRM.Api.Extensions;
using CRM.Application;
using CRM.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

app.UseExceptionHandler();

app.MapUsuarioEndpoints();

app.Run();