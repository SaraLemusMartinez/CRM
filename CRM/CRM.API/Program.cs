// Importa los espacios de nombres necesarios para el proyecto.
using CRM.API.Endpoints;
using CRM.API.Models.DAL;
using Microsoft.EntityFrameworkCore;

// crea un nuevo constructor de la aplicacion web.
var builder = WebApplication.CreateBuilder(args);

// Agregar servicio para habilitar la generacion de documento de API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configura y agregar un contexto de base de datos para Entity Framework Core.
builder.Services.AddDbContext<CRMContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("Conn"))
);

// Agrega una instancia de la clase CustomerDAL como un servicio para la inyeccion de dependencias.
builder.Services.AddScoped<CustomerDAL>();

// Contruye la aplicacion web
var app = builder.Build();

// Agrega los puntos finales relacionados con los clientes a la aplicacion.
app.AddCustomerEndpoints();

//Verifica si la aplicacion se esta ejecucutando en un entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    //Habilita el uso de swagger para la documentacion de la API
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Agrega middleware para redirigir las solicitudes HTTP a HTTPS.
app.UseHttpsRedirection();

// Ejecuta la aplicacion
app.Run();