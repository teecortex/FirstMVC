using Grpc.Net.Client;
using Microsoft.AspNetCore.Components.Sections;
using MyHttpClient.Infrastructure;
using Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContext();

// Console.WriteLine(builder.Configuration["AllowedHosts"]);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

using var channel = GrpcChannel.ForAddress("http://localhost:5037");
var sub_client = new SubscriberService.SubscriberServiceClient(channel);
var tariff_client = new TariffService.TariffServiceClient(channel);
var service_client = new ServiceService.ServiceServiceClient(channel);

// var reply = await client.ListSubscribersAsync(new Google.Protobuf.WellKnownTypes.Empty());

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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();