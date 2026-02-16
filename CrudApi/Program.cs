using CrudApi.Data;
using CrudApi.Dtos.Games;
using CrudApi.Dtos.Genres;
using CrudApi.Interfaces;
using CrudApi.Repositories;
using CrudApi.Services;
using CrudApi.Validators.Games;
using CrudApi.Validators.Genres;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// DbContext
builder.Services.AddDbContext<GameDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ??
    "Data Source=Games.db"));

// Services
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();

// Mapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Validator
builder.Services.AddScoped<IValidator<GameCreateDto>, GameCreateValidator>();
builder.Services.AddScoped<IValidator<GameUpdateDto>, GameUpdateValidator>();
builder.Services.AddScoped<IValidator<GenreCreateDto>, GenreCreateValidator>();
builder.Services.AddScoped<IValidator<GenreUpdateDto>, GenreUpdateValidator>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
