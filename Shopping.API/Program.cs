using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using Shopping.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c => 
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shopping.API", Version = "v1" });
});
builder.Services.AddScoped<ProductContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shopping.API v1"));
}

app.UseHttpsRedirection();



app.MapGet("/product", async (ProductContext _context) =>
{

    var result = await _context.Products.Find(p => true).ToListAsync();
    return Results.Ok(result);

});

app.Run();

