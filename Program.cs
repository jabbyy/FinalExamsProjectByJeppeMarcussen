using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Svendeprøve_projekt_BodyFitBlazor.Codes;
using Svendeprøve_projekt_BodyFitBlazor.Data;
using Svendeprøve_projekt_BodyFitBlazor.Repository;
using Svendeprøve_projekt_BodyFitBlazor.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var cs = builder.Configuration.GetConnectionString("Default");
var csFitness = builder.Configuration.GetConnectionString("FitnessDb");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(cs));
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(csFitness));
builder.Services.AddSingleton<Encryption>();
builder.Services.AddSingleton<NavigationClass>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>( options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.SignIn.RequireConfirmedEmail = false;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<DataContext>();

builder.Services.AddScoped<AuthenticationStateProvider, IdentityValidationProvider<IdentityUser>>();
builder.Services.AddScoped<ITrainingExercisesRepository, TrainingExercisesRepo>();
builder.Services.AddScoped<TrainingExercisesService>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepo>();
builder.Services.AddScoped<CategoriesService>();
builder.Services.AddScoped<IUserProfileRepository, UserRepo>();
builder.Services.AddScoped<UserProfileService>();
builder.Services.AddScoped<IExercisesAddedToLogRepo, ExerciseAddedToLogRepo>();
builder.Services.AddScoped<ExerciseAddedToLogService>();
builder.Services.AddScoped<ITrainingLogRepo, TrainingLogRepo>();
builder.Services.AddScoped<TrainingLogService>();
builder.Services.AddScoped<UserRepo>();



builder.Services.AddSingleton<AESEncryption>(sp =>
{
    byte[] encryptionKey = Encoding.UTF8.GetBytes("YourSecureKeyOf32Characters!1234"); // Key 
    return new AESEncryption(encryptionKey);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
