using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using WebApplication2.Controllers;
using WebApplication2.Data;
using WebApplication2.Data.Repository;
using WebApplication2.Models;
using WebApplication2.Services;
using WebApplication2.Services.Interfaces;
using WebApplication2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<IKlienciService, KlienciService>();
builder.Services.AddScoped<IKlienciRepository, KlienciRepository>();
builder.Services.AddScoped<IRoweryRepository, RoweryRepository>();

builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<KlienciViewModelValidator>());

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Identity services properly with default UI
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI(); // This is important for Identity UI pages

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;

    // Lockout settings
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings
    options.User.RequireUniqueEmail = true;
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("WyzszeUpr", policy =>
        policy.RequireRole("Admin", "Manager"));
});

// Configure cookie settings (important for login functionality)
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.LoginPath = "/Areas/Pages/Identity/Account/Login";
    options.LogoutPath = "/Identity/Account/Logout";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});

var app = builder.Build();

// Create roles and assign users
async Task CreateRolesAsync(RoleManager<IdentityRole> roleManager)
{
    string[] roles = { "Admin", "Manager", "User" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

async Task AssignRoleIfUserExists(UserManager<IdentityUser> userManager, string email, string role)
{
    var user = await userManager.FindByEmailAsync(email);
    if (user != null && !await userManager.IsInRoleAsync(user, role))
    {
        await userManager.AddToRoleAsync(user, role);
    }
}

// Initialize roles and assign users
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

    await CreateRolesAsync(roleManager);

    var adminEmail = "mikolaj@wp.pl";
    var creatorEmail = "creator@gmail.com";
    var userEmail = "user@example.com"; // Fixed invalid email address

    await AssignRoleIfUserExists(userManager, adminEmail, "Admin");
    await AssignRoleIfUserExists(userManager, creatorEmail, "Manager");
    await AssignRoleIfUserExists(userManager, userEmail, "User");
}

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "admin",
    pattern: "Admin/{action=Index}",
    defaults: new { controller = "Admin" });

app.MapControllerRoute(
    name: "adminUsers",
    pattern: "AdminUsers/{action=Index}/{id?}",
    defaults: new { controller = "AdminUsers" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// This is critical for Identity UI pages to work
app.MapRazorPages();

app.Run();