using Microsoft.EntityFrameworkCore;
using PIM3.Data;
using PIM3.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BancoContext>
 (options => options.UseSqlServer
 ("Server=ANDER;Database=PimDataBase;Trusted_Connection=True;MultipleActiveResultSets=false;TrustServerCertificate=Yes"));
builder.Services.AddScoped<IGerenciarRepositorio, GerenciarRepositorio>(); // VERIFICAR SE VAI FUNCIONAR

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();