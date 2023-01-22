using MediatrDemo.Library.Data;
using MediatR;
using MediatrDemo.Library.Model;
using MediatrDemo.Library;
using Azure.Identity;
using Microsoft.ApplicationInsights.DependencyCollector;
using Microsoft.EntityFrameworkCore;
using MediatrDemo.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddAzureKeyVault(
    new Uri("https://webapi-keyvault.vault.azure.net/"),
    new DefaultAzureCredential());

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IDataRepository, DataRepository>();
builder.Services.AddMediatR(typeof(MovieModel).Assembly);
builder.Services.AddDbContext<DbContexts>(options => options.UseSqlServer(
    builder.Configuration["dbURL"], b => b.MigrationsAssembly("MediatrDemo")));
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationInsightsTelemetry(builder.Configuration["AppInsights"]);


builder.Services.AddTransient<RequestBodyLoggingMiddleware>();
builder.Services.AddTransient<ResponseBodyLoggingMiddleware>();

builder.Services.ConfigureTelemetryModule<DependencyTrackingTelemetryModule>((module, o) =>
    { module.EnableSqlCommandTextInstrumentation = true; });

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpLogging();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movies API");
});

app.UseMiddleware<RequestBodyLoggingMiddleware>();
app.UseMiddleware<ResponseBodyLoggingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();

