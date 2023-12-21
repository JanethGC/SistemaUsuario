using Microsoft.EntityFrameworkCore;
using SistemaUsuario.Models; //AGREGAR
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<AgendaPruebaTecnicaReactContext>(); //AGREGAR

builder.Services.AddDbContext<AgendaPruebaTecnicaReactContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"))); //AGREGAR


//No permite las consultas cicladas
builder.Services.AddControllers().AddJsonOptions( opt => {

    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;

});

//Permite que la API sea consumida desde cualquier dominio sin que CORS lo bloquee, hay que activarla al final para que se ejecute. 1/2
var misReglasCors = "ReglasCors";
builder.Services.AddCors(opt => {

    opt.AddPolicy( name : misReglasCors, builder => {

        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    
    });

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

//Activa las reglas escritas para CORS, 2/2
//app.UseCors(misReglasCors);

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
