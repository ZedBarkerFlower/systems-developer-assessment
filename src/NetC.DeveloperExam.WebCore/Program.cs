using NetC.DeveloperExam.WebCore.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSystemWebAdapters();
builder.Services.AddHttpForwarder();

// Add services to the container.
builder.Services.AddControllersWithViews();

// DI injectio
builder.Services.AddScoped<BlogService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.UseSystemWebAdapters();

app.MapDefaultControllerRoute();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllerRoute(
        name: "blog",
        pattern: "blog/{id:int}",
        defaults: new { controller = "Blog", action = "Index" });
});

app.Run();
