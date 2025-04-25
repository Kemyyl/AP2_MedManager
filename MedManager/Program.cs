using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore; 
using AP2_MedManager.Data;
using AP2_MedManager.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDefaultIdentity<Medecin>(options =>
  {
      options.SignIn.RequireConfirmedAccount = false;
    //   options.Password.RequireDigit = true;
    //   options.Password.RequireLowercase = true;
    //   options.Password.RequireNonAlphanumeric = true;
    //   options.Password.RequireUppercase = true;
      options.Password.RequiredLength = 8;

      options.User.RequireUniqueEmail = true;
  }
).AddEntityFrameworkStores<ApplicationDbContext>();



var serverVersion = new MySqlServerVersion(new Version(11, 0, 2));

// Ajout du dbcontext au service container
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), serverVersion)
);

builder.WebHost.UseUrls("http://127.0.0.1:5050");


var app = builder.Build();

app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Acount}/{action=Login}/{id?}");


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error/Index");
    app.UseStatusCodePagesWithRedirects("../Error/Index"); // Gère les erreurs comme 404
}

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
context.Database.EnsureCreated();

app.UseStaticFiles(); // Enable static files

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Index}/{id?}");

app.Run();
