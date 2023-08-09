using userManagement.data;
using userManagement.Models;

var builder = WebApplication.CreateBuilder(args);

dbConn conn = new dbConn();
Muser user = new Muser()
{
    first_name = "jorge",
    last_name = "rojas",
    username = "username",
    email = "email",
    password = "password",
};
//conn.openConn();
//conn.newUser(user, conn);

string[] features = { "first_name", "username" };
string[] values = { "Alberto", "Pasada" };
conn.updateUser(1, features, values,conn);

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
