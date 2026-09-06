using GameLauncher.Data;
using GameLauncher.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString
("DefaultConnection")));
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!context.Games.Any())
    {
        context.Games.AddRange(
            new Game {Id = 1 , Title = "Hollow Knight:Silksong"},
            new Game {Id = 2 , Title = "Deadlock"},
            new Game {Id = 3 , Title = "Omori"},
            new Game {Id = 4 , Title = "Portal2"},
            new Game {Id = 5 , Title = "Nine Sols"}
        );
    }
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
