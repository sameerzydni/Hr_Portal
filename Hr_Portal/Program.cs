using Hr_Portal.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews() .AddNewtonsoftJson();
builder.Services.AddCors();
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("NewConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//    app.UseExceptionHandler("/Home/Error");
//    app.UseHsts();
//}

app.UseDeveloperExceptionPage();

app.UseHsts();

app.UseCors(options =>
options.WithOrigins("*")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin());

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Resume}/{action=Index}/{id?}");

app.Run();
