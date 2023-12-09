using Module10Test.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

#region Logging 

var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/RestaurantLog.txt", rollingInterval: RollingInterval.Minute)
    .MinimumLevel.Information()
    // .MinimumLevel.Warning()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger); // log provider

#endregion

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IProductRepo, FakeProductRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //Change the environment variable value:--> right clikc of project and select properties.  Now slect debug and open the debug profile and change the variable
    app.UseExceptionHandler("/Home/Error"); //is the environment is not development then this page will show
   //app.UseDeveloperExceptionPage(); 
    //This will open up developer page
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
