using GeographyCore.Services;
using GeographyStracture.Data.Entities;
using GeorgaphyStracture.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<GeographyDb>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddDefaultIdentity<User>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.SignIn.RequireConfirmedAccount = false;
    options.User.RequireUniqueEmail = true;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<GeographyDb>();

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ContinentService>();
builder.Services.AddScoped<CountryServices>();
builder.Services.AddScoped<CityServices>();
builder.Services.AddScoped<MountaineService>();
builder.Services.AddScoped<RiverService>();
builder.Services.AddScoped<RegisterService>();

builder.Services.AddAuthentication()
    .AddGoogle(googleOptions =>
    {
        googleOptions. ClientId = "463323973575-j4d5aqcp0fetfmngeo9gfun37eudm43u.apps.googleusercontent.com";
        googleOptions.ClientSecret = "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";
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminsOnly", policy => policy.RequireRole("Admin"));
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();

app.MapControllerRoute(
      name: "default",
      pattern: "{controller=Home}/{action=Index}/{id?}"

    );

app.MapControllerRoute(
      name: "Adminstration",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"

    );

app.MapRazorPages();

app.Run();
