using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NZWalksAPI.Data;
using NZWalksAPI.Mappings;
using NZWalksAPI.Repositories;
using StreamSync.Services;
using StreamSync.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// injetando dbcontext e definindo connection string
builder.Services.AddDbContext<NZWalksDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalksConnectionString")));

// injetando repositório SQL SERVER
builder.Services.AddScoped<IRegionRepository, InMemoryRepository>();
builder.Services.AddScoped<ISpotifyApiService, SpotifyApiService>();
builder.Services.AddScoped<IDeezerApiService, DeezerApiService>();
builder.Services.AddScoped<IStreamSyncService, StreamSyncService>();

//// repository inmemory para testes
//builder.Services.AddScoped<IRegionRepository, InMemoryRepository>();

// injetanto automapper e profile
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

// Adicionando o IHttpClientFactory
builder.Services.AddHttpClient();

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
