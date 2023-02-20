using APISteam.Domain.Interface;
using APISteam.Infra.Data;
using APISteam.Infra.Repositories;
using APISteam.Web.Configurations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContextPool<DataContext>(opt =>
                opt.UseMySql(mySqlConnection,ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddScoped<DataContext, DataContext>();

// repository dependency injections.

builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();


builder.Services.AddApplicationServices();
builder.Services.AddDomainServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using(var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
        dbContext.Database.EnsureCreated();
    }
    
    app.UseSwagger();
    app.UseSwaggerUI();
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
