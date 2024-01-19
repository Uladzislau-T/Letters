using System.Text.Json.Serialization;
using Letters.API;
using Letters.API.Middlewares;
using Letters.Infrastructure;
using Letters.Infrastructure.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var isDev = builder.Environment.IsDevelopment();

var conStr = builder.Configuration.GetConnectionString("letterConn");

// Console.WriteLine("--> Using Docker Db");
builder.Services.AddDbContext<Context>(opt =>
    opt.UseNpgsql(conStr, b => b.MigrationsAssembly("Letters.API")));

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.Configure<ApiBehaviorOptions>(options
    => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.MapControllers();

await PrepDb.PrepPopulation(app, isDev);

app.Run();