using ExoApi.Contexts;
using ExoApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("ExoApiDatabase")!;

builder.Services.AddDbContext<ExoContext>(options => 
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllers();

builder.Services.AddScoped<ProjetoRepository>();

var app = builder.Build();

app.MapControllers();

app.Run();