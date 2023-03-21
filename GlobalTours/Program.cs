using Core.Interfaces;
using Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); // variable q capture la db

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ILugarRepositorio, LugarRepositorio>();

var app = builder.Build();

// aplicar las nuevas migraciones al ejecutar la app
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;// se obtiene el servicio
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();// se obtiene el logger

    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();// se obtiene el contexto
        await context.Database.MigrateAsync();// se ejecuta la migracion
        await BaseDatosSeed.SeedAsync(context, loggerFactory);// se ejecuta el seed
    }
    catch (SystemException e)
    {
        var logger = loggerFactory.CreateLogger<Program>();// se crea el logger
        logger.LogError(e, "Un error ocurrió al migrar la base de datos");// se muestra el error
    }
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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
