using ApplicationCore;
using GraphqlClient.Infrastructure;
using GrpcClient.Infrastructure;
using MyHttpClient.Infrastructure;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddApplication();

builder.Services.AddMyHttpClient();

builder.Services.AddMyGrpcClient();
builder.Services.AddSubscriberGrpcService();

builder.Services.AddMyGraphQlClient();
builder.Services.AddSubscriberGraphqlService();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSerilogRequestLogging();

app.UseRouting();


app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();