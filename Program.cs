using desafioRH.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RecursosHumanosContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));
builder.Services.AddDbContext<RegistroLogContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("RegistroLog")));



builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();  // Página de exceção detalhada para ambientes de desenvolvimento.
}
else
{
    app.UseExceptionHandler("/RecursosHumanos/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=RecursosHumanos}/{action=Index}/{id?}");

app.Run();
