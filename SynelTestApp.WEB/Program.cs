using Syncfusion.Licensing;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddApplicationServices(builder.Configuration);
SyncfusionLicenseProvider.RegisterLicense("Mgo + DSMBMAY9C3t2VVhjQlFac1lJXHxIYVF2R2BJd1Ryc19EZEwgOX1dQl9hSHxTdEVrW3deeHxVQmE =");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Employee/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}");

app.Run();
