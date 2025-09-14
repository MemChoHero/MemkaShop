using MemkaShop.Core.Constants;
using MemkaShop.Core.DependencyInjection;
using MemkaShop.WebApi.Jwt;
using MemkaShop.WebApi.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDatabaseServices(builder.Configuration[AppSettingsConstants.ConnectionString]!);
builder.Services.AddDomainServices();
builder.Services.AddInteractors();
builder.Services.AddRepositories();
builder.Services.AddSecurity();

builder.Services.AddTransient<JwtProcessor>();

builder.Services.Configure<AuthOptions>(builder.Configuration.GetSection("AuthOptions"));

builder.Services.AddAuthorization();

var authOptions = builder.Configuration.GetSection("AuthOptions").Get<AuthOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = authOptions!.Issuer,
            ValidateAudience = true,
            ValidAudience = authOptions.Audience,
            ValidateLifetime = true,
            IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true,
        };
    });

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
