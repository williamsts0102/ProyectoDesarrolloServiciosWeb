using Microsoft.EntityFrameworkCore;
using ProyectoDesarrolloServiciosWeb.DataAccess.Data;
using ProyectoDesarrolloServiciosWeb.DataAccess.Repository;
using ProyectoDesarrolloServiciosWeb.DataAccess.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//agregar
//especificar que se utilizara sqlServer, obtiene la cadena de conexion
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


/*agregar conexion para categoria*/
//builder.Services.AddScoped<ICategoriaRepository , CategoriaRepository > ();

/*con la nueva unidad para que el codigo este mas limpio*/
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

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
    pattern: "{area=Cliente}/{controller=Home}/{action=Index}/{id?}");

app.Run();
