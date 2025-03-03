var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure logging with SetMinimumLevel
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));




// Add code-based filters
builder.Logging.AddFilter("Microsoft", LogLevel.Warning);  // Only log warnings and above for Microsoft
builder.Logging.AddFilter("System", LogLevel.Error);       // Only log errors for System
builder.Logging.AddFilter("Filter_poc.Controllers", LogLevel.Debug); // Debug level for Filter_poc


//// Add a custom filter
//builder.Logging.AddProvider(new CustomLogFilter(LogLevel.Information));

//// Add global category filter extension
//builder.Logging.AddGlobalCategoryFilter("MyAppNamespace", LogLevel.Information);   

// DYNAMIC LOGGING

var loggerFactory = LoggerFactory.Create(logging =>
{
    logging.AddConsole();
    logging.AddFilter((category, level) =>
        category.Contains("Filter_poc") && level >= LogLevel.Debug);
});

var logger = loggerFactory.CreateLogger("Filter_poc.Controllers");
logger.LogDebug("This is a Debug log.");
logger.LogWarning("This is a Warning log.");

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
