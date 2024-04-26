using ApplicationCore;
using ApplicationCore.RepositoryContracts;
using Infrastructure.Data;
using Infrastructure.Repository;
using Infrastructure.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
#region repository_injection
//Repository injection
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
#endregion

//service injection
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddDbContext<EcommerceDbContext>(context => {
    context.UseSqlServer(builder.Configuration.GetConnectionString("ECommerceDb"));

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
