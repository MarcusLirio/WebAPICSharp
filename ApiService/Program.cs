using ClienteDataBaseSetting;
using ClientService;
using ContatoClienteService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ClientDataBaseSetting>
    (builder.Configuration.GetSection("DevNetStoreDatabase"));

builder.Services.AddSingleton<ClienteService>();
builder.Services.AddSingleton<ContatoClienteServices>();


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
