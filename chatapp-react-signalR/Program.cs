using chatapp_react_signalR.Hubs;
using chatapp_react_signalR.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddSingleton<IDictionary<string,UserConnection>>(opt => new Dictionary<string,UserConnection>());

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseRouting();

app.UseCors();

app.MapHub<ChatHub>("/chat");

app.Run();
