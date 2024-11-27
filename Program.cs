using Microsoft.EntityFrameworkCore;
using firstProject; // Remplacez par votre namespace


var builder = WebApplication.CreateBuilder(args);

// Récupérer la chaîne de connexion depuis appsettings.json
var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");

// Ajouter le service DbContext avec MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

// Ajouter les services nécessaires
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurez le pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Servir les fichiers statiques

app.UseRouting();
app.UseAuthorization();

// Routes pour les contrôleurs
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();