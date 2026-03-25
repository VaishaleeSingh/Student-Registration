using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using RegistrationAPI.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Native MongoDB Client
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var mongoClient = new MongoClient(connectionString);
var database = mongoClient.GetDatabase("RegistrationDb");

// Register IMongoCollection as a singleton/scoped service
builder.Services.AddSingleton<IMongoCollection<Registration>>(sp => 
    database.GetCollection<Registration>("registrations"));

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:5173", "http://localhost:4200");
    });
});

var app = builder.Build();

// Always enable Swagger for visibility as requested
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthorization();
app.MapControllers();

app.Run();
