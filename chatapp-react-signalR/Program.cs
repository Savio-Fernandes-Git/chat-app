using chatapp_react_signalR.Hubs;

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

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseRouting();

app.UseCors();

app.MapHub<ChatHub>("/chat");

app.Run();
