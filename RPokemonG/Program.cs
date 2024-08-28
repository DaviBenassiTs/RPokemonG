using RPokemonG.SignalHub;
using RPokemonG.Builders;

var builder = WebApplication.CreateBuilder(args);//puxa todos os builders de WebApplication

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.DBContext();//encapsulado em builders
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
app.UseCorsApp();//encapsulado em builders

app.MapHub<ChatHub>("/hub");

app.UseDefaultFiles();//Habilita o mapeamento de arquivo padrão no caminho atual
//permite que o servidor localize e forneça o arquivo index.html
app.UseStaticFiles();//Habilita o serviço de arquivo estático para o caminho da solicitação atual

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
