//using ManageStudents.Infrastructure.Encryption;
//using ManageStudents.Infrastructure;
//using Microsoft.AspNetCore.DataProtection;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllersWithViews();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();


using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using ManageStudents.API.Application;
using ManageStudents.API.Application.Authorization;
using ManageStudents.API.Application.Middleware;
using ManageStudents.API.Setup;
using ManageStudents.Infrastructure;
using ManageStudents.Infrastructure.Encryption;

var builder = WebApplication.CreateBuilder(args);

{
    //builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwagger(builder.Configuration);
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddApplication();
    builder.Services.AddScoped<HttpClientAuthorizationDelegatingHandler>();
    builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    builder.Services.ConfigureSecurityAndAuthentication(builder.Configuration);
    builder.Services.ConfigureHttpClients(builder.Configuration);
    builder.Services.Configure<AppSettings>(builder.Configuration);
    builder.Services.AddTransient<IEncryptor, Encryptor>();
    builder.Services.ConfigureCors();
    //builder.Services.ConfigureScheduledTasks();

    var appName = builder.Environment.ApplicationName;

    builder.Services.AddDataProtection()
        .SetApplicationName(appName)
        .PersistKeysToDbContext<KeysContext>()
        .SetDefaultKeyLifetime(TimeSpan.FromDays(builder.Environment.IsProduction() ? 30 : 7));
}

var app = builder.Build();

//app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.ConfigureSwagger();

app.ConfigureCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Use(async (context, next) =>
{
    if (!context.Request.Path.Value.Contains("/swagger", StringComparison.OrdinalIgnoreCase)
        && !context.Request.Path.Value.Contains("/api/", StringComparison.OrdinalIgnoreCase))
    {
        if (!app.Environment.IsDevelopment())
        {
            context.Response.Redirect("/ManageStudents/swagger");
        }
        return;
    }

    await next();
});

app.UseMiddleware(typeof(ErrorHandlingMiddleware));

using (var scope = app.Services.CreateScope())
{
    var keyDb = scope.ServiceProvider.GetRequiredService<KeysContext>();
    keyDb.Database.Migrate();
    var db = scope.ServiceProvider.GetRequiredService<StudentContext>();
    db.Database.Migrate();
}

app.Run();