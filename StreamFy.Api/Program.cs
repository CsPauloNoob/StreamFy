using Microsoft.EntityFrameworkCore;
using StreamFy.Application;
using StreamFy.Infra.Dados;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<UsuarioApplication>();

#if DEBUG
builder.Services.AddDbContext<StramFyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
#endif

builder.Services.AddDbContext<StramFyContext>(options =>
    options.UseSqlServer(Environment.GetEnvironmentVariable("conn"))
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();