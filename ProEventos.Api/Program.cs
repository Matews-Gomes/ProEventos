using ProEventos.Api.Configurations;
using Microsoft.EntityFrameworkCore;
using ProEventos.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbContextConfig>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ResolveDependences();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(access => access.AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin()
);

app.MapControllers();

app.Run();
