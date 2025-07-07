using RAPI;

var builder = WebApplication.CreateBuilder(args);

// Configure logging
builder.Services.AddLogging(logging =>
{
    logging.AddConsole()
           .AddDebug()
           .SetMinimumLevel(LogLevel.Information);
});

// Register AppLogger as a Singleton
builder.Services.AddSingleton<AppLogger>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection(); // disabled
app.UseAuthorization();
app.MapControllers();

app.Run();