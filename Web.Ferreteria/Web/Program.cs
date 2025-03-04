using Abstractions.BC;
using Authorization.Abstractions.BW;
using Authorization.Abstractions.DA;
using Authorization.DA;
using Authorization.Middleware;
using BC;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Auth config
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    options =>
    {
        options.LoginPath = "/Account/IniciarSesion";
        options.AccessDeniedPath = "/Account/AccesoDenegado";
    });

// Add services to the container.
builder.Services.AddControllersWithViews();

// injección de servicios
builder.Services.AddScoped<IConfiguracion, Configuracion>();
// Security packages
builder.Services.AddTransient<IDapperRepositoryDA, DapperRepository>();
builder.Services.AddTransient<ISecurityDA, Security>();
builder.Services.AddTransient<IAuthorizationBW, Authorization.BW.Authorization>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.AuthorizationClaims();

app.UseAuthorization();

// Custom name routes
app.MapControllerRoute(
    name: "Cuenta",
    pattern: "Cuentas/{action=Index}/{id?}",
    defaults: new { controller = "Account" });


app.MapControllerRoute(
    name: "Privacidad",
    pattern: "Privacidad",
    defaults: new { controller = "Home", action = "Privacy" });


app.MapControllerRoute(
    name: "Categorias",
    pattern: "Categorias/{action=Index}/{id?}",
    defaults: new { controller = "Categories" });

app.MapControllerRoute(
    name: "Personas",
    pattern: "Personas/{action=Index}/{id?}",
    defaults: new { controller = "People" });


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
