
using Microsoft.EntityFrameworkCore;
using Aplicacao.Data;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>(
    options => options.UseSqlite("Data Source=hotel.db;Cache=shared")
);

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(
    cors => cors.AllowAnyOrigin().
    AllowAnyMethod().
    AllowAnyHeader()
);

app.UseCors("AllowAll");
app.UseRouting();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
