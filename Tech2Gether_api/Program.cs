using Tech2Gether_api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();



// Set Database Connection String
var databaseConnectionString = builder.Configuration["Connection"];

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

// Run the app
app.Run();