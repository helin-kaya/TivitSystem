using System.Globalization;
using AddressBook_BL.EmailSenderProcess;
using AddressBook_PL.CreateDefaultData;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TivitSystemBL.ImplementationOfManagers;
using TivitSystemBL.InterfacesOfManagers;
using TivitSystemDL.ContextInfo;
using TivitSystemDL.ImplementationofRepos;
using TivitSystemDL.InterfaceofRepos;
using TivitSystemEL.IdentityModels;
using TivitSystemEL.Mappings;
using TivitSystemEL.ViewModels;
using TivitSystemPL.Models;

var builder = WebApplication.CreateBuilder(args);
var cultureInfo = new CultureInfo("tr-TR");

CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Services.AddDbContext<MyContext>(options =>
{
    //klasik mvcde connection string web configte yer alir.
    //core mvcde connection string appsetting.json dosyasindan alinir.
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyLocal"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

});
builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{
    opt.Password.RequiredLength = 8;
    opt.Password.RequireNonAlphanumeric = true;
    opt.Password.RequireLowercase = true;
    opt.Password.RequireUppercase = true;
    opt.Password.RequireDigit = true;
    opt.User.RequireUniqueEmail = true;
    //opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+&%";

}).AddDefaultTokenProviders().AddEntityFrameworkStores<MyContext>();

builder.Services.AddAutoMapper(a =>
{
    a.AddExpressionMapping();
    a.AddProfile(typeof(Maps));
    a.CreateMap<SendTivitViewModel, UserTivitViewModel>().ReverseMap();
    a.CreateMap<AppUser, ProfileViewModel>();
});



builder.Services.AddScoped<IEmailManager, EmailManager>();


builder.Services.AddScoped<ITivitTagsRepo, TivitTagsRepo>();
builder.Services.AddScoped<ITivitTagsManager, TivitTagsManager>();

builder.Services.AddScoped<IUserTivitRepo, UserTivitRepo>();
builder.Services.AddScoped<IUserTivitManager, UserTivitManager>();

builder.Services.AddScoped<IUserTivitMediaRepo, UserTivitMediaRepo>();
builder.Services.AddScoped<IUserTivitMediaManager, UserTivitMediaManager>();


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); //login logout
app.UseAuthorization(); //yetki

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

        var roleManager = serviceProvider.
    GetRequiredService<RoleManager<AppRole>>();

    //CreateData c = new CreateData();
    CreateData c = new CreateData(logger);
    //c.CreateRoles(serviceProvider);

}
app.Run();
