using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddDbContextPool<DataContext>(opt =>
                opt.UseMySql("server=localhost;port=3306;database=pokedexdatabase;user=root;password={Senha do seu banco de dados mysql};Persist Security Info=false;Connect Timeout=300",
                        ServerVersion.AutoDetect("server=localhost;port=3306;database=pokedexdatabase;user=root;password={Senha do seu banco de dados mysql};Persist Security Info=false;Connect Timeout=300")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
