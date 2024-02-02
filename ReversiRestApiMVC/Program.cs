using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReversiRestApiMVC;
using ReversiRestApiMVC.Controllers;
using ReversiRestApiMVC.Hubs;

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

app.UseStaticFiles();

app.UseRouting();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.MapHub<GameHub>("/gameHub");

app.Run();