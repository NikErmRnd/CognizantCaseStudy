using CognizantCaseStudy.DB;
using CognizantCaseStudy.DB.Services;
using CognizantCaseStudy.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Server=(localdb)\\mssqllocaldb;Database=cognizantCaseStudydb;Trusted_Connection=True;";
var clientId = "8dbc6c1850ea086b887475419747fdfe";
var clientSecret = "ba42531f32e9ce9e66941145d96138d1b71f6a8bc937f5d0972090c31d9be18";

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddTransient<ICodeChallengeRepository, CodeChallengeRepository>();
builder.Services.AddTransient<ICodeChallengeSubmitterService>(s => new CodeChallengeSubmitterService(clientId, clientSecret));
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
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
