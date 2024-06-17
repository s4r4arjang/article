using AtrinCode.Core.ApplicationServices.Articles;
using AtrinCode.Core.ApplicationServices.Articles.DomainService;
using AtrinCode.Core.Contracts.Common;
using AtrinCode.Core.Contracts.Repositories.Articles;
using AtrinCode.Core.Contracts.Services.Articles;
using AtrinCode.Core.Contracts.Services.Articles.Command;
using AtrinCode.Core.Domain.DomainServices.Articles;
using AtrinCode.Core.Domain.Entities.Articles.DomainContract;
using AtrinCode.Infrastructures.EFCore.Articles;
using AtrinCode.Infrastructures.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("AtrinDB");

//var connectionString = builder.Configuration.GetConnectionString("sajad");
builder.Services.AddDbContext<AtrinDbContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<IValidationCategory, ValidationCategory>();
builder.Services.AddScoped<IValidationArticle, ValidationArticle>();


builder.Services.AddCors();
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });
}
else
{
    builder.Services.AddControllersWithViews().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

}


//   یا
//#if DEBUG

//#else

builder.Services.AddAntiforgery();
builder.Services.AddAuthorization();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // sajad
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseCors();  
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
/// <summary>
///    https://github.com/dotnet/aspnetcore/issues/40609
///    اینو بخون حال نداشتم
/// </summary>
app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
