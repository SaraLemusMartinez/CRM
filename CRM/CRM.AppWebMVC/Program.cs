var builder = WebApplication.CreateBuilder(args);//Crear un constructor de aplicaciones web

// Agregar servicios al contenedor de dependencias.
builder.Services.AddControllersWithViews(); // Agregar servicios para controladores y vista

//Configura y agrega un cliente HTTP con nombre "CRMAPI"
builder.Services.AddHttpClient("CRMAPI", c =>
{
    //Configura la direccion base del cliente HTTP desde la configuracion
    c.BaseAddress = new Uri(builder.Configuration["UrlsAPI:CRM"]);
    //Puedes configurar otrasopciones del HttpClient aqui segun sea necesario
});

var app = builder.Build(); // Crear una instancia de la aplicacion web

// Configura el pipeline de solicitudes HTTP.
if (!app.Environment.IsDevelopment())
{
    //Maneja excepciones en caso de errores y redirige a la accion "Error" en el controlador "home"
    app.UseExceptionHandler("/Home/Error");
    // El valor HSTS predeterminado es de 30 dias puedes cambiarlo para escenariosde produccion
    app.UseHsts();
}

app.UseHttpsRedirection();//Resirige las solicitudes HTTP a HTTPS
app.UseStaticFiles();// Habilita el uso de archivos estaticos como CSS, JavaScript, imagines etc.

app.UseRouting(); // Configura si el enrutamiento de solicitudes

app.UseAuthorization();// Habilita la autorizacion para proteger rutas y acciones de controladores

//Mapea la ruta predeterminada de controladores y accion
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run(); //inicia la aplicacion
