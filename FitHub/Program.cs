using FitHub.Data;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FitContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("fitConnection"));
});

// Obtener la configuración de la cadena de conexión
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json")
    .Build();



builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});
builder.Services.AddFluentValidation(config =>
{
    config.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});
var app = builder.Build();

using (var scope=app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<FitContext>();
    context.Database.Migrate();
}
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
