using Microsoft.EntityFrameworkCore;
using webapi.Extensions;
using webapi.Services;
using webAPI.DBOperations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BookStoreDbContext>(
    options => options.UseInMemoryDatabase(databaseName: "BookStoreDB")
);
builder.Services.AddSingleton<ILoggerService,ConsoleLogger>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//var host =app;
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    webAPI.DBOperations.DataGenerator.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseExceptionMiddle();//?Custom Middleware

app.MapControllers();

app.Run();
