using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReversiRestApi;
using ReversiRestApi.Controllers;
using ReversiRestApi.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<SpelController>();
builder.Services.AddSingleton<ISpelRepository, SpelAccessLayer>();
builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true;
}); 
;
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.MapHub<GameHub>("/gameHub");

app.Run();