using AutoMapper;
using Megazine_Practice.Data;
using Megazine_Practice.Repository.RepoImplementation;
using Megazine_Practice.Services.ServiceImpl;
using Megazine_Practice.Services.ServiceInterface;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<UnitOfWorkRepoImpl>();
builder.Services.AddScoped<IArticlesService, ArticlesServiceImpl>();
builder.Services.AddScoped<IEmployeeService, EmployeeServiceImpl>();
builder.Services.AddScoped<IJournalServicecs, JournalServiceImpl>();
builder.Services.AddScoped<IUserActivityFilter, UserActivityFilter>();
builder.Services.AddScoped<INewsService, NewsServiceImpl>();

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(typeof(UserActivityFilter));
});

builder.Services.AddDbContext<AppDbContext>(x=>x.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

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
