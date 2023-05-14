using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using ReactAspCrud.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SalesDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SalesDbContext")));
//builder.Services.AddDbContext<SalesContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SalesContext")));

var app = builder.Build();

app.UseCors(policy => policy.AllowAnyHeader()
                            .AllowAnyMethod()
                            .SetIsOriginAllowed(origin => true)
                            .AllowCredentials());
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
