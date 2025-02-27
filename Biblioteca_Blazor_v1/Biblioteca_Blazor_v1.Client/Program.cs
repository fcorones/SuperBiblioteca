using BibliotecaDeClasesWinformYBlazor.Servicios;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

//Instancia el constructor de la app blazor WASM
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<AuthContext>(); //registra AuthContext
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});
builder.Services.AddScoped<LibroService>(sp =>
{
    var authContext = sp.GetRequiredService<AuthContext>();
    return new LibroService(authContext);
});


builder.Services.AddScoped<PrestamoService>(sp =>
{
    var authContext = sp.GetRequiredService<AuthContext>();
    return new PrestamoService(authContext);
});


//Registra el servicio en el contenedor de dependencias. Una nueva instancia x cada conexión
builder.Services.AddScoped<UsuarioService>(sp => 
{
    var authContext = sp.GetRequiredService<AuthContext>(); // Devuelve una instancia de AuthContext
    return new UsuarioService(authContext); //UsuarioService necesita la instancia de AuthContext para funcionar
});

builder.Services.AddHttpClient<IGeorefService, GeorefService>(client =>
{
    client.BaseAddress = new Uri("https://apis.datos.gob.ar/georef/api/");
});


var host = builder.Build();

// Inicializar AuthContext
var authContext = host.Services.GetRequiredService<AuthContext>();
authContext.Initialize();

await host.RunAsync();