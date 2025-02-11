using Biblioteca_Blazor_v1.Components;
using BibliotecaDeClasesWinformYBlazor;
using BibliotecaDeClasesWinformYBlazor.Servicios;
using MudBlazor.Services;


var builder = WebApplication.CreateBuilder(args);

// Registrar servicios
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddHttpClient();

// Registrar AuthContext como un servicio
builder.Services.AddScoped<AuthContext>();

// Registrar LibroService
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

builder.Services.AddHttpClient<IGeorefService, GeorefService>();


// Registrar MudBlazor
builder.Services.AddMudServices();


var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Biblioteca_Blazor_v1.Client._Imports).Assembly);

app.Run();