using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using OfficialUnlimitedDBIntegration.Core;
using Serilog;
using System.Reflection;
using Unlimited.Repository;
using Unlimited.Repository.Interfaces;
using Unlimited.Repository.Repositories;
using Unlimited.Service.Interfaces;
using Unlimited.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( options =>
{
  // Add support for XML comments
  var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
  var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
  options.IncludeXmlComments(xmlPath);
});

//Add logging
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

//Add DBContext
var connectionString = builder.Configuration.GetConnectionString("UnlimitedDbContext");
builder.Services.AddDbContext<UnlimitedDbContext>(options =>
    options.UseNpgsql(connectionString));

//Api Versioning
builder.Services.AddApiVersioning(options =>
{
  options.DefaultApiVersion = new ApiVersion(1);
  options.ReportApiVersions = true;
  options.AssumeDefaultVersionWhenUnspecified = true;
  options.ApiVersionReader = ApiVersionReader.Combine(
      new UrlSegmentApiVersionReader(),
      new HeaderApiVersionReader("X-Api-Version"));
}).AddApiExplorer(options =>
{
  options.GroupNameFormat = "'v'V";
  options.SubstituteApiVersionInUrl = true;
});

//Add Services etc
builder.Services.AddScoped<IApiClient, ApiClient>();
builder.Services.AddScoped<IUnlimitedClient, UnlimitedClient>();
builder.Services.AddScoped<ICardService, CardService>();

builder.Services.AddScoped<ICardRepository, CardRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}
else
{
  app.UseExceptionHandler("/Error");
}

//Add support to logging request with SERILOG
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
