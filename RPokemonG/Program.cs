using RPokemonG.Models;
using RPokemonG.Services;
using RPokemonG.SignalHub;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<DatabaseSettings>
    (builder.Configuration.GetSection("DatabaseSettings"));//define a configuração que deve ser usada no appsettings

builder.Services.AddSingleton<FichaServices>();
builder.Services.AddSingleton<EspecieServices>();
builder.Services.AddSingleton<ElementoServices>();
builder.Services.AddSignalR();

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

app.MapHub<ChatHub>("/hub");

app.UseDefaultFiles();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
