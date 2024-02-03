<<<<<<< HEAD
using JWTRefreshToken.Auth;
using JWTRefreshToken.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using NETCore.MailKit.Core;
using System.Text;
using System;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;
// For Entity Framework
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));

// IEmailService implementation using MailKit
builder.Services.AddMailKit(optionBuilder =>
{
    optionBuilder.UseMailKit(new MailKitOptions()
    {
        Server = configuration["ExternalProviders:MailKit:SMTP:Address"],
        Port = Convert.ToInt32(configuration["ExternalProviders:MailKit:SMTP:Port"]),
        Account = configuration["ExternalProviders:MailKit:SMTP:Account"],
        Password = configuration["ExternalProviders:MailKit:SMTP:Password"],
        SenderEmail = configuration["ExternalProviders:MailKit:SMTP:SenderEmail"],
        SenderName = configuration["ExternalProviders:MailKit:SMTP:SenderName"],
        // Set it to TRUE to enable ssl or tls, FALSE otherwise
        Security = true
    });
});
// For Identity

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddTransient<ApplicationDbContext>();
builder.Services.AddScoped<JWTRefreshToken.Auth.IEmailService, JWTRefreshToken.Auth.EmailService>();
builder.Services.AddScoped<IEmployees, EmployeeRepository>();

builder.Services.Configure<DataProtectionTokenProviderOptions>(opts => opts.TokenLifespan = TimeSpan.FromHours(10));

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero,

        ValidAudience =builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});
///Manohar doing some changes
//Real time changes on 2-03-2024 -------
builder.Services.AddControllers();
builder.Services.AddTransient<ExceptionMiddleware>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var _policyName = "CorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: _policyName,
    builder =>
    {
        builder.WithOrigins("http://localhost:4200","http://localhost:83","https://localhost:7009")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                  .AllowCredentials();
    });
    options.AddPolicy("AllowHeaders", builder =>
    {///WeatherForecast
        //builder.WithOrigins("http://localhost:4200","http://localhost:83","https://localhost:7009")
        builder.WithOrigins("*")
           .WithHeaders(HeaderNames.ContentType, HeaderNames.Server,
           HeaderNames.AccessControlAllowHeaders, HeaderNames.AccessControlExposeHeaders,
           "x-custom-header", "x-path", "x-record-in-use", HeaderNames.ContentDisposition);
    });
    //enable single domain
    //enable multiple domain
    //any domain

});

var app = builder.Build();


// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    // Other middleware...
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(_policyName);

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
=======
using JWTRefreshToken.Auth;
using JWTRefreshToken.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using NETCore.MailKit.Core;
using System.Text;
using System;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;
// For Entity Framework
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));

// IEmailService implementation using MailKit
builder.Services.AddMailKit(optionBuilder =>
{
    optionBuilder.UseMailKit(new MailKitOptions()
    {
        Server = configuration["ExternalProviders:MailKit:SMTP:Address"],
        Port = Convert.ToInt32(configuration["ExternalProviders:MailKit:SMTP:Port"]),
        Account = configuration["ExternalProviders:MailKit:SMTP:Account"],
        Password = configuration["ExternalProviders:MailKit:SMTP:Password"],
        SenderEmail = configuration["ExternalProviders:MailKit:SMTP:SenderEmail"],
        SenderName = configuration["ExternalProviders:MailKit:SMTP:SenderName"],
        // Set it to TRUE to enable ssl or tls, FALSE otherwise
        Security = true
    });
});
// For Identity

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddTransient<ApplicationDbContext>();
builder.Services.AddScoped<JWTRefreshToken.Auth.IEmailService, JWTRefreshToken.Auth.EmailService>();
builder.Services.AddScoped<IEmployees, EmployeeRepository>();

builder.Services.Configure<DataProtectionTokenProviderOptions>(opts => opts.TokenLifespan = TimeSpan.FromHours(10));

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero,

        ValidAudience =builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});
///Manohar doing some changes
//Real time changes on 2-03-2024 -------
builder.Services.AddControllers();
builder.Services.AddTransient<ExceptionMiddleware>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var _policyName = "CorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: _policyName,
    builder =>
    {
        builder.WithOrigins("http://localhost:4200","http://localhost:83","https://localhost:7009")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                  .AllowCredentials();
    });
    options.AddPolicy("AllowHeaders", builder =>
    {///WeatherForecast
        //builder.WithOrigins("http://localhost:4200","http://localhost:83","https://localhost:7009")
        builder.WithOrigins("*")
           .WithHeaders(HeaderNames.ContentType, HeaderNames.Server,
           HeaderNames.AccessControlAllowHeaders, HeaderNames.AccessControlExposeHeaders,
           "x-custom-header", "x-path", "x-record-in-use", HeaderNames.ContentDisposition);
    });
    //enable single domain
    //enable multiple domain
    //any domain

});

var app = builder.Build();


// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    // Other middleware...
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(_policyName);

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
>>>>>>> 646d16442dedfc2db17fe2938d2b24f3dba80ab8
