using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Okta.AspNetCore;
using Okta_DotNet_SQL_Injection.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.Always;
})
.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie()
.AddOktaMvc(new OktaMvcOptions
{
    // Replace these values with your Okta configuration
    OktaDomain = builder.Configuration.GetValue<string>("Okta:OktaDomain"),
    AuthorizationServerId = builder.Configuration.GetValue<string>("Okta:AuthorizationServerId"),
    ClientId = builder.Configuration.GetValue<string>("Okta:ClientId"),
    ClientSecret = builder.Configuration.GetValue<string>("Okta:ClientSecret"),
    Scope = new List<string> { "openid", "profile", "email" },
});

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ProductsDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddTransient<Okta_DotNet_SQL_Injection.Services.Interfaces.IProductService, Okta_DotNet_SQL_Injection.Services.ProductService>();
builder.Services.AddTransient<Okta_DotNet_SQL_Injection.Services.Interfaces.IProductCodeValidator, Okta_DotNet_SQL_Injection.Services.ProductCodeValidator>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

ProductsDbInitializer.Seed(app);

app.Run();