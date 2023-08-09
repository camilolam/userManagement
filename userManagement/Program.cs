using userManagement.data;

var builder = WebApplication.CreateBuilder(args);

dbConn conn = new dbConn();
String query = "INSERT INTO public.users (first_name, last_name, username, email, password) VALUES('camilo','canaveral','camilo1234','camilo.lam93@gmail.com','camilo123456')  ";
//conn.openConn();
conn.command(query, conn);
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
