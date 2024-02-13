using Fish_Shop;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Html;
using Fish_Shop.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Fish_Shop.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Fish_ShopContextConnection") ?? throw new InvalidOperationException("Connection string 'Fish_ShopContextConnection' not found.");

// Add services to the container.

builder.Services.AddDbContext<Fish_ShopContext>();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<Fish_ShopContext>();
builder.Services.AddTransient<ITimeService, TimeService>();
builder.Services.AddTransient<IDateService, DateService>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
//Authorization
builder.Services.AddAuthorization();
builder.Services.AddAuthentication();
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = AuthOptions.ISSUER,
//        ValidAudience = AuthOptions.AUDIENCE,
//        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey()
//    };
//});

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

app.Use(async (context, next) =>
{       
    Console.WriteLine($"DATA Seeding.............................");
    /*
    using (ApplicationContext db = new ApplicationContext())
    {
        try
        {
            User user1 = new User() { Name = "user1name", Surname = "user1surname", Patronymic = "user1patronymic" };
            User user2 = new User() { Name = "user2name", Surname = "user2surname" };
            User user3 = new User() { Name = "user3name" };
            db.AddRange(user1, user2, user3);

            //---------------------------------------------Ryba
            Product product1 = new Product()
            {
                Name = $"����� �����",
                Amount = 10,
                ShortDescription = $"����� (���. Botia) � ��� ��� �� ��������� Botiidae. ������� � ������ ������ ���-��������� ����. ������ �������������� � ��������������.",
                ImageFile = $"ryba_����� �����.jpg",
                Units = "p�s",
                Cost = 10
            };
            Product product2 = new Product()
            {
                Name = $"������������ �������",
                Amount = 20,
                ShortDescription = $"������������ ������� (���. Apistogramma) � ��� �� ����� ��� ��� ����� �������� ��� �� ��������� ��������, ��������� � ����������� ������� �������� �������� � ���������.",
                ImageFile = $"ryba_������������ �������.jpg",
                Units = "p�s",
                Cost = 13
            };
            Product product3 = new Product()
            {
                Name = $"����������� �����������",
                Amount = 30,
                ShortDescription = $"����������� ������������������ (Neolamprologus tretocephalus) � ������������ �������� ����� �� ��������� ��������. �������� ��������� ������������ ����� ����������.",
                ImageFile = $"ryba_����������� �����������.jpg",
                Units = "p�s",
                Cost = 14
            };
            Product product4 = new Product()
            {
                Name = $"��������������� �����������",
                Amount = 99,
                ShortDescription = $"��������������� ����������� (Paracyprichromis nigripinnis) � ������������ �������� ����� �� ��������� ��������. �������� ��������� ������������ ����� ����������.",
                ImageFile = $"ryba_��������������� �����������.jpg",
                Units = "p�s",
                Cost = 14
            };
            Product product5 = new Product()
            {
                Name = $"����������� �������",
                Amount = 25,
                ShortDescription = $"�������������� ������� (Neolamprologus similis) � ������������ �������� ����� �� ��������� ��������. �������� ��������� ����� ����������.",
                ImageFile = $"ryba_����������� �������.jpg",
                Units = "p�s",
                Cost = 4
            };
            Product product6 = new Product()
            {
                Name = $"���������",
                Amount = 25,
                ShortDescription = $"��������� (���. Xiphophorus) - ��� �������� ��� ��������� ���������� ������ �����������������. �������������� � ������� ����� ����������� �������.",
                ImageFile = $"ryba_���������.jpg",
                Units = "p�s",
                Cost = 5
            };
            Product product7 = new Product()
            {
                Name = $"���� �������",
                Amount = 25,
                ShortDescription = $"���� ������� � �������� �������� ���� ��� ��� ����� ������, �� ����� ����� ���������� ����������.",
                ImageFile = $"ryba_���� �������.jpg",
                Units = "p�s",
                Cost = 5
            };
            Product product8 = new Product()
            {
                Name = $"����� ������������",
                Amount = 25,
                ShortDescription = $"����� ������������ (Laetacara dorsigera) � ������������ �������� ����� �� ��������� ��������. ������� ���� �������� ����� �������.",
                ImageFile = $"ryba_����� ������������.jpg",
                Units = "p�s",
                Cost = 5
            };
            Product product9 = new Product()
            {
                Name = $"�����������",
                Amount = 25,
                ShortDescription = $"����������� (Homaloptera sp.) � ��� ������������ �������� ��� �� ��������� �����������. � ��������� ����� �������� � ���� ����� �����. ������� ����� �������� ���-��������� ����.",
                ImageFile = $"ryba_�����������.jpg",
                Units = "p�s",
                Cost = 5
            };
            Product product10 = new Product()
            {
                Name = $"�����",
                Amount = 25,
                ShortDescription = $"����� � �������� ����� ��� ���������� �������������. ��� �� �������� ������� ��� ����������, �� ��������� �������� ���������� � ������ ����� ���� ������.",
                ImageFile = $"ryba_�����.jpg",
                Units = "p�s",
                Cost = 5
            };
            //---------------------------------------------Trava
            Product product11 = new Product()
            {
                Name = $"�������� ���",
                Amount = 25,
                ShortDescription = $"�������� ��� (Vesicularia ferriei, ����. Weeping Moss) � ������ ��� �� ��������� ��������. ��� ������������� �������� ���� �� �����.",
                ImageFile = $"trava_�������� ���.jpg",
                Units = "p�s",
                Cost = 5
            };
            Product product12 = new Product()
            {
                Name = $"����� ������",
                Amount = 25,
                ShortDescription = $"����� ������, ��� ��������� ������ (Nymphoides aquatica) � ����������� �������� �� ��������� ��������. ��� ������������� ����� �� �������� �������.",
                ImageFile = $"trava_����� ������.jpg",
                Units = "p�s",
                Cost = 5
            };
            Product product13 = new Product()
            {
                Name = $"��������� ����������",
                Amount = 25,
                ShortDescription = $"��������� ���������� (Lysimachia nummularia) � ����������� �������� �� ��������� ������������. ��� ������ ������������� �� ���������� �������, � ����� ��� ������� � �������� �������.",
                ImageFile = $"trava_��������� ����������.jpg",
                Units = "p�s",
                Cost = 5
            };
            Product product14 = new Product()
            {
                Name = $"����������� ������������",
                Amount = 25,
                ShortDescription = $"����������� ������������ (Heteranthera zosterifolia) � ���������������� ����������� �������� �� ��������� �������������. ������� ���� �������� ����� �������.",
                ImageFile = $"trava_����������� ������������.jpg",
                Units = "p�s",
                Cost = 5
            };
            Product product15 = new Product()
            {
                Name = $"������������� �������",
                Amount = 25,
                ShortDescription = $"������������� ������� (Alternanthera sessilis) � ���������������� ����������� �������� �� ��������� �����������. ������� ���� �������� ����� �������, �� � ��������� ����� �� ����������� �� ������ ����������� ��������.",
                ImageFile = $"trava_������������� �������.jpg",
                Units = "p�s",
                Cost = 5
            };
            Product product16 = new Product()
            {
                Name = $"���������� ������",
                Amount = 25,
                ShortDescription = $"���������� ������ (Helanthium tenellum, ����� Echinodorus tenellus) � �������� ����������� �������� �� ��������� ����������. � ������� ����������� � ��������, ����������� � ����� �������.",
                ImageFile = $"trava_���������� ������.jpg",
                Units = "p�s",
                Cost = 5
            };
            Product product17 = new Product()
            {
                Name = $"������������� ��������",
                Amount = 25,
                ShortDescription = $"������������� �������� (�����������) (Alternanthera bettzickiana) � ���������������� ����������� �������� �� ��������� �����������. ������� ���� �������� ��������.",
                ImageFile = $"trava_������������� ��������.jpg",
                Units = "p�s",
                Cost = 5
            };
            Product product18 = new Product()
            {
                Name = $"�����������  ������������",
                Amount = 25,
                ShortDescription = $"����������� ������������, ��� ���������� ������������ (Utricularia graminifolia) � �������������� ����������� �������� �� ��������� �������������. � ������� ����������� � ���-��������� ����.",
                ImageFile = $"trava_�����������  ������������.jpg",
                Units = "p�s",
                Cost = 5
            };
            Product product19 = new Product()
            {
                Name = $"������ �����������",
                Amount = 25,
                ShortDescription = $"������ ����������� (Azolla caroliniana) � ��������� ����������� �������� �� ��������� ������������. ������� ���� �������� �������� �������.",
                ImageFile = $"trava_������ �����������.jpg",
                Units = "p�s",
                Cost = 5
            };
            Product product20 = new Product()
            {
                Name = $"������ ��������",
                Amount = 25,
                ShortDescription = $"������ ��������, ��� ��������������� (Egeria densa, ����� � Elodea densa) � ���������������� ����������� �������� �� ��������� ������������. � ������� �������� ������ ����� �������.",
                ImageFile = $"trava_������ ��������.jpg",
                Units = "p�s",
                Cost = 5
            };


            db.AddRange(product1, product2, product3, product4, product5, product6, product7, product8, product9, product10, product11, product12, product13, product14, product15, product16, product17, product18, product19, product20);               

                              
               Order order1 = new Order()
               {
                   User = user1,
                   Address = "bobrovsk street",
                   Comment = "nugno bystro",
                   Products = { product1, product2 }
               };
               Order order2 = new Order()
               {
                   User = user1,
                   Address = "zoltay street",
                   Comment = "brykni brykni",
                   Products = { product1, product2, product3 }
               };
               Order order3 = new Order()
               {
                   User = user1,
                   Address = "akademia street",
                   Comment = "zabery u vhoda",
                   Products = { product5, product6 }
               };
               db.AddRange(order1, order2, order3);
               

               db.SaveChanges();
    
            //var users = db.Users.ToList();
            //foreach (var u in users) Console.WriteLine($"User : {u.Id} - {u.Name} - {u.Surname} - {u.Patronymic}");
            var products = db.Products.ToList();
            foreach (var p in products) Console.WriteLine($"Product : {p.Id} - {p.Name} - {p.Description} - {p.ImageFile} - {p.Amount} - {p.Units} - {p.Cost}"); //
            //var orders = db.Orders.ToList();
            //foreach (var o in orders) Console.WriteLine($"Product : {o.Id} - User={o.User.Name} - {o.Comment} - {o.OrderDate}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception message : " + ex.Message);
        }
    }
    */
    await next.Invoke();
});

app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Home}/{action=methmyparams}/{id?}");
    pattern: "{controller=Home}/{action=index}/{id?}");
app.MapControllerRoute(
    name: "auth1",    
    pattern: "{controller=Home}/{action=authcheck}/{id?}");

app.MapControllerRoute(
    name: "MyData1",
    pattern: "{controller=MyData1}/{action=get}");             //https://localhost:7108/MyData1

app.MapControllerRoute(
    name: "NameAgeForm",
    pattern: "{controller=NameAgeForm}/{action=index}");

app.MapControllerRoute(
    name: "ReturnResult",
    pattern: "{controller=ReturnResult}/{action=index}"
	);
app.MapControllerRoute(
	name: "ReturnView",
	pattern: "{controller=ReturnView}/{action=index}"
	);
app.MapControllerRoute(
	name: "ReturnView2",
	pattern: "{controller=ReturnView2}/{action=index}"
	);

app.Run();
