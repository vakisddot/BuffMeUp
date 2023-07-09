using BuffMeUp.Backend.Common;
using BuffMeUp.Backend.Data;
using BuffMeUp.Backend.Services;
using BuffMeUp.Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        builder.Services.AddScoped<ISignUpService, MockSignUpService>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        //builder.Services.AddSwaggerGen();
        //builder.Services.Configure<ApiBehaviorOptions>(options =>
        //{
        //    options.InvalidModelStateResponseFactory = context => {
        //        Console.WriteLine("Something went wrong while trying to bind to a model!");

        //        Console.WriteLine(context.HttpContext.Request.Path.Value);

        //        return new RedirectResult("http://localhost:3000" + context.HttpContext.Request.Path.Value?.ToLower());
        //    };
        //});

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        //if (app.Environment.IsDevelopment())
        //{
        //    app.UseSwagger();
        //    app.UseSwaggerUI();
        //}

        app.UseCors(builder => builder
            .WithOrigins(Endpoints.Endpoint)
            .AllowAnyHeader()
            .AllowAnyMethod()
        );

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}