using RestAspNet8VStudio.Logic;
using RestAspNet8VStudio.Logic.Implementations;
using RestAspNet8VStudio.Data;
using RestAspNet8VStudio.Data.Implementations;
using RestAspNet8VStudio.Model.Context;
using Microsoft.EntityFrameworkCore;
using EvolveDb;
using Serilog;
using Microsoft.OpenApi.Models;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var connection = builder.Configuration["PostgreConnection:PostgreConnectionString"];
builder.Services.AddDbContext<PostgreSQLContext>(options => options.UseNpgsql(
    connection));

if (builder.Environment.IsDevelopment())
{
    MigrateDatabase(connection);
}

//Versionig API
builder.Services.AddApiVersioning();

builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "REST API",
            Version = "V1",
            Description = "API developed in module 2 of BackEnd BootCamp",
            Contact = new OpenApiContact
            {
                Url = new Uri("http://xpeducacao.br")
            }
        });
});

//Dependency Injection
builder.Services.AddScoped<IUserLogic, UserLogicImplementation>();
builder.Services.AddScoped<IHotelLogic, HotelLogicImplementation>();
builder.Services.AddScoped<IRoomLogic, RoomLogicImplementation>();
builder.Services.AddScoped(typeof(IGenericData<>), typeof(GenericDataImplementation<>));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseSwagger();

app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json",
        "API developed in module 2 of BackEnd BootCamp");
});

app.UseAuthorization();

app.MapControllers();

app.Run();

void MigrateDatabase(string connection)
{
    try
    {
        var evolveConnection = new NpgsqlConnection(connection);
        var evolve = new Evolve(evolveConnection,
            msg => Log.Information(msg))
        {
            Locations = new List<string> { "db/migrations", "db/dataset" },
            IsEraseDisabled = true,
        };
        evolve.Migrate();
    }
    catch (Exception ex)
    {
        Log.Error("Database migration failed", ex);
        throw;
    }
}
