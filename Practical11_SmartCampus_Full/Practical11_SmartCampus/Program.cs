using Microsoft.EntityFrameworkCore;
using Practical11_SmartCampus.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CampusDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("CampusConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CampusDbContext>();
    db.Database.EnsureCreated();
    db.ServiceRequests.RemoveRange(db.ServiceRequests);
    db.SaveChanges();
    CampusSeedData.Initialize(db);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
