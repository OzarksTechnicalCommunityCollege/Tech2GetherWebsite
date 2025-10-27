using Tech2Gether_api.Data;
using Microsoft.EntityFrameworkCore;
using ClubWebsite.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add environment variables to configuration
builder.Configuration.AddEnvironmentVariables();

// Set Database Connection String based on environment
string databaseConnectionString;

if (builder.Environment.IsDevelopment())
{
    // Development: Use local configuration (from appsettings.Development.json or user secrets)
    databaseConnectionString = builder.Configuration["Connection"]
        ?? builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Database connection string not found in development configuration.");
}
else
{
    // Production/Release: Use environment variables
    databaseConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Database connection string 'DefaultConnection' not found in environment variables.");
}

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSwaggerGen(setup =>
{
    setup.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Tech2Gether Services",
        Version = "v1",
    });
});
builder.Services.AddDbContext<T2TContext>(options =>
    options.UseMySql(
        databaseConnectionString,
        ServerVersion.AutoDetect(databaseConnectionString)
    ));

// Build the app
var app = builder.Build();

// Configure HTTP request pipeline and Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// Enable authorization
app.UseAuthorization();

// Map Controllers
app.MapControllers();


// Check for data seed command
if (args.Contains("--seed"))
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    
    try
    {
        var context = services.GetRequiredService<T2TContext>();
        var seeder = new DbSeeder(context);
        await seeder.SeedAsync();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\n❌ An error occurred while seeding the database:");
        Console.WriteLine($"   {ex.Message}");
        if (ex.InnerException != null)
        {
            Console.WriteLine($"   Inner exception: {ex.InnerException.Message}");
        }
        Console.WriteLine("\nMake sure you've run migrations first: dotnet ef database update");
        return;
    }
    
    return; // Exit after seeding
}

// Run the app
app.Run();