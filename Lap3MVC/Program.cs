
using Lap3MVC.Models;
using Lap3MVC.Models.Srvices;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Dbconnectionstring")));
builder.Services.AddControllersWithViews();
builder.Services.AddTransient(typeof(IRepository<TaskCategory>),typeof(TaskCategoryRepository));
builder.Services.AddTransient(typeof(IRepository<User>), typeof(UserRepository));
builder.Services.AddTransient(typeof(IRepository<Lap3MVC.Models.Task>), typeof(TaskRepository));



builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromSeconds(10);
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
});
///

var app = builder.Build();
app.UseStaticFiles();
app.UseSession();
app.MapDefaultControllerRoute();



app.Run();
