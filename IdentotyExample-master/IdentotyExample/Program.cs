using IdentotyExample.Data;
using IdentotyExample.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using AutoMapper;
using AlohaAPIExample.Models.Dto;
using AlohaAPIExample.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(MappingProfile));


// Add services to the container.
string defaultConnectionString = "server=127.0.0.1; port=3306; database=testbaza; user=root; password=Sa21sa21sa21!; Persist Security Info=False; Connect Timeout=300";
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySql(defaultConnectionString, ServerVersion.AutoDetect(defaultConnectionString),
        mySqlOptionsAction => mySqlOptionsAction.EnableRetryOnFailure(3))
        .LogTo(Console.WriteLine, LogLevel.Information);
});

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<DataContext>();

builder.Services.AddHttpClient("AlohaAPIClient", client =>
{
    client.BaseAddress = new Uri("https://api.alohaorderonline.com");
    client.Timeout = TimeSpan.FromSeconds(120);
    client.DefaultRequestHeaders.Add("X-Api-CompanyCode", "DLEC001");
    client.DefaultRequestHeaders.Add("PlatformType", "application/json");
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    string username = "api-demo@ds.com";
    string password = "DigitalNCRDigital123@";
    string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
});

builder.Services.AddSingleton<AlohaAPIClient>();

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
