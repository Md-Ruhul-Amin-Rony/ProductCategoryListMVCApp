
// this project was done with the help of this video link below:

///*https://www.youtube.com/watch?v=hZ1DASYd9rk&ab_channel=freeCodeCamp.org*/


using BulkyBookMVCApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options=> options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
//this is the service which will connect with database and so before migration on EF we have to add this service.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
//need to download nuget package: MVC RazorRuntimeCompilation
// with this service razor page will update while refresh pages.
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
