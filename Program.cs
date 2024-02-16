using Fish_Shop;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("Fish_ShopContextConnection") ?? throw new InvalidOperationException("Connection string 'Fish_ShopContextConnection' not found.");

builder.Services.AddDbContext<Fish_ShopContext>();

//IDENTITY
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<Fish_ShopContext>();
//builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<Fish_ShopContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//Authorization
builder.Services.AddAuthorization();
builder.Services.AddAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.MapRazorPages();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Home}/{action=methmyparams}/{id?}");
    pattern: "{controller=Home}/{action=index}/{id?}");

app.Run();
