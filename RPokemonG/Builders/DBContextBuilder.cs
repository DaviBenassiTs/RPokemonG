using RPokemonG.Models;
using RPokemonG.Services;

namespace RPokemonG.Builders
{
    public static class DBContextBuilder
    {
        public static void DBContext(this WebApplicationBuilder builder)
        {
            // Add services to the container.
            builder.Services.Configure<DatabaseSettings>
                (builder.Configuration.GetSection("DatabaseSettings"));//define a configuração que deve ser usada no appsettings

            builder.Services.AddSingleton<FichaServices>();
            builder.Services.AddSingleton<EspecieServices>();
            builder.Services.AddSingleton<ElementoServices>();
        }
    }
}
