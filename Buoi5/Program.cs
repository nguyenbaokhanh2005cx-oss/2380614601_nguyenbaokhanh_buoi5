using Buoi5.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BookDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookDb")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Use(async (context, next) =>
{
    context.Response.OnStarting(() =>
    {
        if (!string.IsNullOrWhiteSpace(context.Response.ContentType)
            && context.Response.ContentType.StartsWith("text/html", StringComparison.OrdinalIgnoreCase)
            && !context.Response.ContentType.Contains("charset=", StringComparison.OrdinalIgnoreCase))
        {
            context.Response.ContentType += "; charset=utf-8";
        }

        return Task.CompletedTask;
    });

    await next();
});

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BookDbContext>();
    context.Database.Migrate();
    SeedData.Initialize(context);
}


app.Run();
