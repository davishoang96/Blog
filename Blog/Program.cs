using Autofac;
using Autofac.Extensions.DependencyInjection;
using Blog.Database;
using Blog.Services.Modules;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new ServiceModules());
        builder.RegisterModule(new RepositoryModule());
    });

var baseUrl = builder.Configuration["BaseUrl"];
var databaseSource = builder.Configuration["DatabaseSource"];
var portNumber = int.Parse(builder.Configuration["PortNumber"]);

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlite($"Data Source={databaseSource}"));

builder.WebHost.UseUrls(baseUrl);

var app = builder.Build();
// Apply migration
using (var scope = ((IApplicationBuilder)app).ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<DatabaseContext>().Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();