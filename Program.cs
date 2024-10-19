using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using PodcastAPI.Interfaces;
using PodcastAPI.Services;
using PodcastAPI.Repositories;
using PodcastAPI.Endpoints;
using PodcastAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<PodcastAPIDbContext>(builder.Configuration["PodcastAPIConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddScoped<IEpisodeService, EpisodeService>();
builder.Services.AddScoped<IEpisodeRepository, EpisodeRepository>();

builder.Services.AddScoped<IPodcastService, PodcastService>();
builder.Services.AddScoped<IPodcastRepository, PodcastRepository>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000")
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapEpisodeEndpoints();
app.MapPodcastEndpoints();
app.MapGenreEndpoints();
app.MapUserEndpoints();

app.Run();
