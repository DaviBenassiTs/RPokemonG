using RPokemonG.Models;
using RPokemonG.Services;
using RPokemonG.SignalHub;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.
builder.Services.Configure<DatabaseSettings>
    (builder.Configuration.GetSection("DatabaseSettings"));//define a configuração que deve ser usada no appsettings

builder.Services.AddSingleton<FichaServices>();
builder.Services.AddSingleton<EspecieServices>();
builder.Services.AddSingleton<ElementoServices>();
builder.Services.AddSignalR();
builder.Services.AddCors();//recebe parametro options


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
app.UseCors(
    builder =>
    {
            builder.SetIsOriginAllowed(origin => true);
            builder.AllowCredentials();
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
    });

app.MapHub<ChatHub>("/hub");

app.UseDefaultFiles();//Habilita o mapeamento de arquivo padrão no caminho atual
//permite que o servidor localize e forneça o arquivo index.html
app.UseStaticFiles();//Habilita o serviço de arquivo estático para o caminho da solicitação atual

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
