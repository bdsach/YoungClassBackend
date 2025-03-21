using Serilog;
using API.Middlewares;
using Domain.Entities;
using Domain.Interfaces.Seeder;
using Application.Extensions;
using Infrastructure.Extensions;
using API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IClassroomsSeeder>();

await seeder.Seed();

// Configure the HTTP request pipeline.
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RequestTimeLoggingMiddleware>();
app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGroup("api/identity")
    .WithTags("Identity")
    .MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();
