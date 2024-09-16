using CorrectionExoIOT.BackgroundServices;
using CorrectionExoIOT.DAL.Repositories;
using CorrectionExoIOT.Infrastructures;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(
    builder.Configuration.GetSection("Mqtt").Get<MqttConnection.Configuration>() 
    ?? throw new Exception("Mqtt Config is missing")
);
builder.Services.AddSingleton<MqttConnection>();
builder.Services.AddHostedService<MqttBackgroundService>();

builder.Services.AddTransient(b => new SqlConnection(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddTransient<InfoMaisonRepository>();

builder.Services.AddCors(b => b.AddDefaultPolicy(o => o.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();
app.UseCors();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();
app.Run();
