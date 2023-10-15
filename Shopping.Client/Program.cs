var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var clientUri = builder.Configuration.GetSection("ShoppingAPIUrl").Value;
builder.Services.AddHttpClient("ShoppingAPIClient", client =>
{
    //client.BaseAddress = new Uri("http://localhost:5000/");   // Shopping.API url in localhost env    
    client.BaseAddress = new Uri($"{ clientUri }");             // get docker URL from docker-compose file as 8000
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
