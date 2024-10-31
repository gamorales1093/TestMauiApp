using BackendTestApp.Infraestructure;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using BackendTestApp.Models.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    CreateTypes(serviceProvider).Wait();
    CreatePropects(serviceProvider).Wait();
}

 static async Task CreateTypes(IServiceProvider serviceProvider)
{
    var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

    var typestoCreate = new string[] { "Llamada", "Mensaje", "Correo" };

    if (context.Types.Any())
        return;

    foreach (var types in typestoCreate)
    {
        context.Types.Add(new Types
        {
            Description = types
        });
    }

    await context.SaveChangesAsync();
}

static async Task CreatePropects(IServiceProvider serviceProvider)
{
    var context = serviceProvider.GetRequiredService<ApplicationDbContext>();


    if (context.Prospects.Any())
        return;

    context.Prospects.Add(new Prospect { FullName = "Juan Surita", Email = "jsurita@gmail.com", Phone = "0985874269",  });
    context.Prospects.Add(new Prospect { FullName = "Juan Gomez", Email = "jgomez@gmail.com", Phone = "0985874285" });
    context.Prospects.Add(new Prospect { FullName = "Paola Bernal", Email = "pbernal@gmail.com", Phone = "0985874210" });
    context.Prospects.Add(new Prospect { FullName = "Pedro Ricaute", Email = "pricaurte@gmail.com", Phone = "0985874212" });
    context.Prospects.Add(new Prospect { FullName = "Oracio Vega", Email = "ovega@gmail.com", Phone = "0985874234" });
    context.Prospects.Add(new Prospect { FullName = "Pablo Morales", Email = "pmorales@gmail.com", Phone = "0985874222" });
    context.Prospects.Add(new Prospect { FullName = "Ernesto Juanes", Email = "ejunaes@gmail.com", Phone = "0985874216" });
    context.Prospects.Add(new Prospect { FullName = "Lepoldo Nerdal", Email = "lnerdal@gmail.com", Phone = "0985874245" });


    await context.SaveChangesAsync();
}

app.Run();


