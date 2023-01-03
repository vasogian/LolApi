using LolApi.SummDbContext;
using LolApi.HttpClients;
using Microsoft.EntityFrameworkCore;
using LolApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<SummonerContextService>();
builder.Services.AddDbContext<SummonerContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

builder.Services.AddHttpClient<RiotHttpClient>(config =>
{
    config.BaseAddress = new Uri("https://eun1.api.riotgames.com");
    config.Timeout = new TimeSpan(0, 0, 45);
    config.DefaultRequestHeaders.Add("X-Riot-Token", "RGAPI-183be6d9-844b-4780-b5d8-d871a8dff071");
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
