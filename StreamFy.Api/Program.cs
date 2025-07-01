using Microsoft.EntityFrameworkCore;
using StreamFy.Application;
using StreamFy.Core.Interfaces;
using StreamFy.Infra.Dados;
using StreamFy.Infra.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<UsuarioApplication>();
builder.Services.AddScoped<PlaylistApplication>();

builder.Services.AddScoped(
    typeof(IUsuarioRepository), 
    typeof(UsuarioRepository));

builder.Services.AddScoped(
    typeof(IMusicaRepository), 
    typeof(MusicaRepository));

#if DEBUG
builder.Services.AddDbContext<StramFyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
#endif

builder.Services.AddDbContext<StramFyContext>(options =>
    options.UseSqlServer(Environment.GetEnvironmentVariable("conn"))
    );

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();