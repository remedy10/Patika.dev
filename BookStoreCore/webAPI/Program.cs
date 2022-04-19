using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using webAPI.DBOperations;
using webAPI.Extensions;
using webAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BookStoreDbContext>(
    options => options.UseInMemoryDatabase(databaseName: "BookStoreDB")
);
builder.Services.AddScoped<IBookStoreDbContext>(
    provider => provider.GetService<BookStoreDbContext>()
); //! IBookStoreDbContext'i inject ediyoroz
builder.Services.AddSingleton<ILoggerService, ConsoleLogger>();
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(
        opt =>
        {
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true, //token'ikimler kullanabilir
                ValidateIssuer = true, //sağlayıcı kimdir
                ValidateLifetime = true, //lifetime kontrolü,tamamlandıysa token expired olacaktır.
                ValidateIssuerSigningKey = true, //imzalama,kriptolamayı kontrol et
                ValidIssuer = builder.Configuration["Token:Issuer"], //6nın nimetlerinden xd
                ValidAudience = builder.Configuration["Token:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])
                ),
                //jsondaki secu keyi encode ediyoruz
                ClockSkew = TimeSpan.Zero //client-host saat farklarını vermek için clockskew ile yapıyoruz.bizim için şimdilik 0
            };
        }
    );
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
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseExceptionMiddle(); //?Custom Middleware

app.MapControllers();

app.Run();
