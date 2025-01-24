using S4.Repositorio.ServiciosRepositorio.CambiosServicios.Extensiones;
using S4.Repositorio.ServiciosRepositorio.CatalogosServicios.Extensiones;
using S4.Repositorio.ServiciosRepositorio.FaltasServicios.Extensiones;
using S4.Repositorio.ServiciosRepositorio.GolServicios.Extensiones;
using S4.Repositorio.ServiciosRepositorio.JugadoresServicios.Extensiones;
using S4.Repositorio.ServiciosRepositorio.PlantelServicios.Extensiones;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//Conexion a BD
builder.Services.AddSingleton(new Conexion(builder.Configuration.GetConnectionString("SQL")!));

//Clases Extensiones para cada Clase
builder.Services.addCambioExtension();
builder.Services.addCatalogosExtension();
builder.Services.addFaltasExtension();
builder.Services.addGeneralExtension();
builder.Services.addGolExtension();
builder.Services.addJugadoresExtension();
builder.Services.addPlantelesExtension();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
