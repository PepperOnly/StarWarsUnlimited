using ApiAuth;
using ApiAuth.Models;
using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Unlimited.Api;
using Unlimited.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure Swagger
builder.Services.ConfigureSwagger(builder.Configuration);
//Settings for Auth
builder.Services.Configure<AuthenticationSettings>(builder.Configuration.GetSection("AuthenticationSettings"));
builder.Services.ConfigureAuthentication(builder.Configuration);

// Add logging
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

// Add DBContext
var connectionStringAuth = builder.Configuration.GetConnectionString("AuthDbContext");
var connectionStringUnlimited = builder.Configuration.GetConnectionString("UnlimitedDbContext");
builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseNpgsql(connectionStringAuth));
builder.Services.AddDbContext<UnlimitedDbContext>(options =>
    options.UseNpgsql(connectionStringUnlimited));

// Api Versioning
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

// Add Services etc
builder.Services.AddCustomRepositories();
builder.Services.AddCustomServices();
builder.Services.AddCustomIntegrations();

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

// Add support to logging request with SERILOG
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

// Use authentication middleware
app.UseAuthMiddleware(builder.Configuration);

app.MapControllers();

app.Run();