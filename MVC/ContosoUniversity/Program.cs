<<<<<<< HEAD
<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ContosoUniversityContext") ?? throw new InvalidOperationException("Connection string 'ContosoUniversityContext' not found.");

builder.Services.AddDbContext<ContosoUniversityContext>(options => options.UseSqlServer(connectionString));
=======
var builder = WebApplication.CreateBuilder(args);
>>>>>>> 81decac088b5e1a86e7c9dc8cfff7c6e805b91ed
=======
var builder = WebApplication.CreateBuilder(args);
>>>>>>> 81decac088b5e1a86e7c9dc8cfff7c6e805b91ed

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
