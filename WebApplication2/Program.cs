using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Data.Repository;
using WebApplication2.Services;
using WebApplication2.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IKlienciService, KlienciService>();
builder.Services.AddScoped<IKlienciRepository, KlienciRepository>();
builder.Services.AddScoped<IRoweryRepository, RoweryRepository>();

builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=./Wypo.db"));

var app = builder.Build();



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