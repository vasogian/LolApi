
using LolApi.HttpClients;
using LolApi.Services;
using LolApi.SummDbContext;
using Microsoft.EntityFrameworkCore;
using Polly;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
    setupAction.IncludeXmlComments(xmlCommentsFullPath);
});
builder.Services.AddScoped<SummonerContextService>();
builder.Services.AddDbContext<SummonerContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAny",
                      policy =>
                      {
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                          policy.AllowAnyOrigin();
                      });
});
builder.Services.AddHttpClient<RiotHttpClient>(config =>
{
    config.BaseAddress = new Uri("https://eun1.api.riotgames.com");
    config.Timeout = new TimeSpan(0, 0, 45);
    config.DefaultRequestHeaders.Add("X-Riot-Token", "RGAPI-741ee440-abd3-4118-81a3-94deb0ef7b43");
}).AddPolicyHandler(Policy
.HandleResult<HttpResponseMessage>(response => !response.IsSuccessStatusCode)
.RetryAsync(3));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAny");

app.UseAuthorization();

app.MapControllers();

app.Run();
