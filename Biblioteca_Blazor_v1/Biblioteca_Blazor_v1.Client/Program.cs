using BibliotecaDeClasesWinformYBlazor.Servicios;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

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

builder.Services.AddSyncfusionBlazor();

var host = builder.Build();

// Inicializar AuthContext
var authContext = host.Services.GetRequiredService<AuthContext>();
authContext.Initialize();

await host.RunAsync();