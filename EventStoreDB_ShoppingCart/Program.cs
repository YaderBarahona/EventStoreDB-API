using EventStore.Client;
using EventStoreDB_ShoppingCart.Hubs;
using EventStoreDB_ShoppingCart.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR(); // Agregar SignalR

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agrega el cliente de EventStoreDB como un servicio singleton.
// Se encarga de registrar el cliente de EventStoreDB en el contenedor de inyección de dependencias.
// Con esto asegurando que se encuentre disponible para ser inyectado en otros componentes
builder.Services.AddSingleton<EventStoreClient>(sp =>
{
    var settings = EventStoreClientSettings.Create("esdb://localhost:2113");
    settings.DefaultCredentials = new UserCredentials("admin", "changeit");
    return new EventStoreClient(settings);
});

builder.Services.AddScoped<IEventStoreService, EventStoreService>();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<HubEvent>("/HubEvent");
});

app.MapControllers();

app.Run();
