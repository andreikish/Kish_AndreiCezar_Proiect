using Kish_AndreiCezar_Project.GrpcServer.Services;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5001, listenOptions =>
    {
        listenOptions.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http2;
    });
});

builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<MaintenanceService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("gRPC Server starting on http://localhost:5001");
logger.LogInformation("Press Ctrl+C to stop the server");

app.Run();
