using HomeSafeServiceProviderNetwork.WebApi;
using HomeSafeServiceProviderNetwork.WebApi.Data.Context;
using HomeSafeServiceProviderNetwork.WebApi.Entities;
using HomeSafeServiceProviderNetwork.WebApi.Interfaces;
using HomeSafeServiceProviderNetwork.WebApi.Interfaces.Config;
using HomeSafeServiceProviderNetwork.Logging;
using HomeSafeServiceProviderNetwork.WebApi.Repositories;
using HomeSafeServiceProviderNetwork.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Negotiate;
using NLog;
using NLog.Web;

var logger = LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config")).GetCurrentClassLogger();
logger.Debug("init main");

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate();

//builder.Services.AddSingleton<
//    IAuthorizationMiddlewareResultHandler, AuthorizationHandler>();

var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var env = config.GetSection("Environment").Value;

builder.Configuration.AddJsonFile("appsettings.json", false, true);
builder.Configuration.AddJsonFile($"appsettings.{env}.json", true, true);

// NLog: Setup NLog for Dependency injection
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();

// Add services to the container.
builder.Services.AddSingleton((IHspnServiceConfig)builder.Configuration
                .GetSection(HspnServiceConfig.ConfigSectionName)
                .Get<HspnServiceConfig>());

builder.Services.AddSingleton<HspnContext>();
builder.Services.AddScoped<ILoggerManager, LoggerManager>();

builder.Services.AddScoped<IHspnService, HspnService>();
builder.Services.AddScoped<IHspnRepository, HspnRepository>();

//builder.Services.AddSingleton((ISecurityConfig)builder.Configuration
//                .GetSection(SecurityConfig.ConfigSectionName)
//                .Get<SecurityConfig>());

builder.Services.AddCors(opt => {
    opt.AddPolicy("CorsPolicy", policy => {
        policy.AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowedToAllowWildcardSubdomains()
        .WithOrigins("http://localhost:4200",
                        "http://127.0.0.1:4200",
                        "https://*.shieldpay.carshield.com",
                        "https://*.shieldpayment.carshield.com",
                        "https://*.carshield.com",
                        "https://qa.shieldpayment.carshield.com/",
                        "https://qa.shieldpay.carshield.com/",
                        "https://dev.shieldpay.carshield.com",
                        "https://dev.shieldpayment.carshield.com",
                        "https://shieldpayment.carshield.com",
                        "https://shieldpay.carshield.com"
                        );
    });
});





// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ConnectionStringOptions>(builder.Configuration.GetSection(ConnectionStringOptions.Position));

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
