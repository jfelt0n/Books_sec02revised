using Books_sec02revised.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// ftech the information about the connection string 
var connstring = builder.Configuration.GetConnectionString("DefaultConnection");

//add the context class to the set of services and define the option to use sql server 
builder.Services.AddDbContext<BooksDBContext>(options => options.UseSqlServer(connstring));

builder.Services.AddIdentity<IdentityUser,IdentityRole>
    ().AddEntityFrameworkStores<BooksDBContext>
    ().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Logout";
    options.LogoutPath = $"Identity/Account/Logout";
    options.AccessDeniedPath = $"Identity/Account/AccessDenied";
});




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
    pattern: "{Area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
