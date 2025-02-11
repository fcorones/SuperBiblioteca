using BibliotecaDeClasesWinformYBlazor.Servicios;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<AuthContext>();
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

builder.Services.AddScoped<UsuarioService>(sp =>
{
    var authContext = sp.GetRequiredService<AuthContext>();
    return new UsuarioService(authContext);
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