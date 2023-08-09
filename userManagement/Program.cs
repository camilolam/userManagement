using userManagement.data;
using userManagement.Models;

var builder = WebApplication.CreateBuilder(args);
// -------------------------------------------------------------inicio para pruebas de funcionamiento ---------------------

dbConn conn = new dbConn();
Muser user = new Muser()
{
    first_name = "Valentina",
    last_name = "Pabon",
    username = "Valhola123",
    email = "email@email.com",
    password = "bonito123",
};
//conn.openConn();
//conn.newUser(user, conn);

string[] features = { "first_name", "username" };
string[] values = { "Alberto", "Pasada" };
//conn.updateUser(1, features, values,conn);

///conn.deleteUser(1, conn);
conn.listUsers(conn);

//-------------------------------------------------------------- fin para pruebas de funcionamiento ---------------------


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
