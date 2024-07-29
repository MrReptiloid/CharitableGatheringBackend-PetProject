using DonateSVO.API.Extentions;
using DonateSVO.Application.Interfaces;
using DonateSVO.Core.Abstractions;
using DonateSVO.DataAccess;
using DonateSVO.DataAccess.Repository;
using DonateSVO.Infrastructure;
using DonateSVO.Services.Services;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
    
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApiAuthentication(builder.Configuration);

builder.Services.AddDbContext<DonateSvoDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(DonateSvoDbContext)));
    });

builder.Services.AddScoped<IGatheringRepository, GatheringRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IGatheringService, GatheringService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x =>
{
    x.WithOrigins("http://localhost");
    x.WithMethods().AllowAnyMethod();
    x.WithHeaders().AllowAnyHeader();
    x.AllowCredentials();
});

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.None,
    HttpOnly = HttpOnlyPolicy.None,
    Secure = CookieSecurePolicy.Always
});

app.UseHttpsRedirection();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();

app.Run(); 