using BuffMeUp.Backend.Common;
using BuffMeUp.Backend.Data;
using BuffMeUp.Backend.Services;
using BuffMeUp.Backend.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BuffMeUp.Backend;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString =
                builder.Configuration.GetConnectionString("DefaultConnection") 
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        builder.Services.AddDbContext<BuffMeUpDbContext>(options =>
            options.UseSqlServer(connectionString));

        // Add services to the container.
        builder.Services.AddScoped<IAccountService, AccountService>();
        builder.Services.AddScoped<IRoleService, RoleService>();
        builder.Services.AddScoped<IPersonalStatsService, PersonalStatsService>();

        builder.Services.AddScoped<IWorkoutService, WorkoutService>();
        builder.Services.AddScoped<IExerciseTemplateService, ExerciseTemplateService>();
        builder.Services.AddScoped<IExerciseSetService, ExerciseSetService>();

        builder.Services.AddScoped<IMealService, MealService>();
        builder.Services.AddScoped<IFoodItemService, FoodItemService>();
        builder.Services.AddScoped<IPortionService, PortionService>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                ValidateIssuer = true,
                ValidAudience = builder.Configuration["JwtSettings:Audience"],
                ValidateAudience = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    builder.Configuration["JwtSettings:Key"])),
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true
            };
        });

        builder.Services.AddAuthorization();

        var app = builder.Build();

        //Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(builder => builder
            .WithOrigins(Endpoints.FrontendEndpoints.Select(e => $"{e}:{Endpoints.FrontendPort}").ToArray())
            .AllowAnyHeader()
            .AllowAnyMethod()
        );

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}