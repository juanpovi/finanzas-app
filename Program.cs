using Microsoft.EntityFrameworkCore;
using WebApi2026Jmp1.Data;

namespace WebApi2026Jmp1;

public class Program
{
    public static void Main(string[] args)
    {
        // Crea el builder principal de la aplicacion.
        var builder = WebApplication.CreateBuilder(args);

        // Registra soporte para Controllers (arquitectura basada en controladores).
        builder.Services.AddControllers();

        // Registra servicios de Swagger para documentar y probar la API.
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Obtiene el string de conexion a PostgreSQL desde appsettings.json.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        // Registra AppDbContext y define que use PostgreSQL con Entity Framework Core.
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

        // Construye la aplicacion con todos los servicios registrados.
        var app = builder.Build();

        // Habilita middleware de Swagger y la interfaz Swagger UI.
        app.UseSwagger();
        app.UseSwaggerUI();

        // Fuerza redireccion de HTTP a HTTPS.
        app.UseHttpsRedirection();

        // Habilita autorizacion (queda lista para una etapa futura).
        app.UseAuthorization();

        // Mapea automaticamente las rutas de todos los controllers.
        app.MapControllers();

        // Inicia la aplicacion web.
        app.Run();
    }
}
