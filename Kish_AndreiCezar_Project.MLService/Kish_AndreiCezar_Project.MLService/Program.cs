using Kish_AndreiCezar_Project.MLService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<PredictionEngineService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("ML Service starting on http://localhost:5002");
logger.LogInformation("Press Ctrl+C to stop the server");

app.Run();
