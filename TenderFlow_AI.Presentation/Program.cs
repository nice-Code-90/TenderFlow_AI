using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TenderFlow_AI.Application.Common.Interfaces;
using TenderFlow_AI.Infrastructure.Persistence;
using TenderFlow_AI.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TenderFlowDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IOrganizationContextRepository, OrganizationContextRepository>();
builder.Services.AddScoped<TenderFlow_AI.Application.Services.OnboardingService>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference(options =>
    {
        options.WithTitle("TenderFlow AI API")
               .WithTheme(ScalarTheme.Moon)
               .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
