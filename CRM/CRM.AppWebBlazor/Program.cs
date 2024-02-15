using CRM.AppWebBlazor.Data; //Importa el espacio de nombres donde se encuentre CustomerrService

var builder = WebApplication.CreateBuilder(args);

// Agraga servicios al contenedor de dependencias
builder.Services.AddRazorPages();//Agrega soporte para paginas razor
builder.Services.AddServerSideBlazor();// Agrega soporte para Blazor en el lado del servidor

//Registra CustomerService como un servicio Singleton (una instancia unica para toda la aplicacion
builder.Services.AddSingleton<CustomerService>();

//Configura y agrega un cliente HTTP con nombre "CRMAPI"
builder.Services.AddHttpClient("CRMAPI", c =>
{
    //configura la direccion base del cliente HTTP  desde la configuracion
    c.BaseAddress = new Uri(builder.Configuration["UrlsAPI:CRM"]);
    // Puedes configurar otras opciones de HttpClient aqui segun sea necesario
});

var app = builder.Build();// Crea una instancia de la aplicacion web

// Configura el pipeline de solicitudes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");//Maneja excepciones en caso de errores
    // El valor HSTS preseterminado es de 30 dias puedes cambiarlo para escenarios de produccion.
    app.UseHsts();
}

app.UseHttpsRedirection();//Redirige las solicitudes HTTP  a HTTPS

app.UseStaticFiles();// Habilita el uso de archivos estaticos como CSS, JavaScript, imagenes, etc

app.UseRouting(); // Configura el enrutamiento de solicitudes

app.MapBlazorHub();// Mapea BlazorHub para habilitar la funcionalidad de Blazor en tiempo real
app.MapFallbackToPage("/_Host");//Mapea la pagina_Host para servir aplicacion Blazor

app.Run();// Inicia la aplicacion
