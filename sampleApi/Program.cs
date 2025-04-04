using AutoMapper;
using Microsoft.EntityFrameworkCore;
using sampleApi;
using sampleApi.Application;
using sampleApi.Application.Interfaces;
using sampleApi.Application.Services;
using sampleApi.Core;
using sampleApi.Infrastructure;
using sampleApi.Infrastructure.Model;

var builder = WebApplication.CreateBuilder(args);
string sqlConnection = builder.Configuration.GetConnectionString("SqlConnection");
builder.Services.AddDbContext<SampleApiDbContext>(options =>
{
    options.UseSqlServer(sqlConnection);
});
//Fill Class Configs From appsettings
builder.Services.AddOptions();
//Configuration اشاره میکنه به فایل اپ ستینگز
builder.Services.Configure<Configs>(builder.Configuration.GetSection("Configs"));
// Add services to the container.
builder.Services.AddJwt();
builder.Services.AddRepositories();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IUserRefreshTokenService, UserRefreshTokenService>();
builder.Services.AddUnitOfWork();
builder.Services.AddEncryptionUtility();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    // تعریف نسخه‌های API
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "VAHID_API Version 1",
        Version = "v1",
        Description = "Description for version 1 of the API"
    });
    c.EnableAnnotations();
});
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.ConfigureApplicationServices();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();




app.MapControllers();

app.Run();
