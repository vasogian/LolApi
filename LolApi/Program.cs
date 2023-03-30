using LolApi.SummDbContext;
using LolApi.HttpClients;
using Microsoft.EntityFrameworkCore;
using LolApi.Services;
using LolApi.Policies;
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
builder.Services.AddHttpClient<RiotHttpClient>(config =>
{
    config.BaseAddress = new Uri("https://eun1.api.riotgames.com");
    config.Timeout = new TimeSpan(0, 0, 45);
    config.DefaultRequestHeaders.Add("X-Riot-Token", "RGAPI-515a8525-a976-4d51-a7e6-06d34b5cf287");
}).AddPolicyHandler(RetryPolicy.GetRetryPolicy());

var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseSwagger();

app.UseSwaggerUI(c => c.InjectStylesheet("/swagger/custom.css"));
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
