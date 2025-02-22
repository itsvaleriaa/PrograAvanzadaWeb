using Abstractions.BC;
using BC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// injección de servicios
builder.Services.AddScoped<IConfiguracion, Configuracion>();

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

app.UseAuthorization();

// Custom name routes
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
