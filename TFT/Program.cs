using LolApi.HttpClients;
using TFT.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<RiotHttpClient>(config =>
{
    config.BaseAddress = new Uri("https://eun1.api.riotgames.com");
    config.Timeout = new TimeSpan(0, 0, 45);
<<<<<<< Updated upstream
    config.DefaultRequestHeaders.Add("X-Riot-Token", "RGAPI-c26e79d4-9610-47c5-ac0d-a17126cfe1f4");
});
builder.Services.AddHttpClient<TftHttpClient>(config => {
    config.BaseAddress = new Uri("https://eun1.api.riotgames.com");
    config.Timeout = new TimeSpan(0, 0, 45);
    config.DefaultRequestHeaders.Add("X-Riot-Token", "RGAPI-c26e79d4-9610-47c5-ac0d-a17126cfe1f4");
=======
    config.DefaultRequestHeaders.Add("X-Riot-Token", "RGAPI-0f306110-22c1-4823-af28-b416174fbc91");
>>>>>>> Stashed changes
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
