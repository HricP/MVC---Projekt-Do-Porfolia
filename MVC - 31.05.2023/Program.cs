using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC___31._05._2023.Models;
using MVC___31._05._2023.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<ApplicationDbContext>(options => { 
//    options.UseSqlServer(
//        builder.Configuration["ConnectionString: SchoolDbConnection"])});

//builder.Services.AddDbContext<ApplicationDbContext>(options => {
//    options.UseSqlServer(
//        builder.Configuration["ConnectionString: SchoolDbConnection"]);
//});//

//------------------------------------------------------------------------

//builder.Services.AddDbContext<ApplicationDbContext>(options => {
//    options.UseSqlServer(
//        builder.Configuration.GetConnectionString("SchoolDbConnection"));
//});

//AzureDbConnection
builder.Services.AddDbContext<ApplicationDbContext>(options => {
	options.UseSqlServer(
		builder.Configuration.GetConnectionString("AzureDbConnection"));
});




builder.Services.AddIdentity<AppUser,
    IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options => {
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 8;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = ".AspNetCore.Identity.Application";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(1);
    options.SlidingExpiration = true;
});

builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<SubjectsService>();
builder.Services.AddScoped<GradeService>();



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

app.Run();