using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RPokemonG.Models;

namespace RPokemonG.Services
{
    public class DatabaseSetting
    {
        private readonly IMongoCollection<Ficha> _fichaCollection;//somente leitura - puxa a tabela e crio o nome

        public FichaServices(IOptions<DatabaseSettings> fichaService)//Configura database
        {
            var mongoClient = new MongoClient(fichaService.Value.ConnectionString);//puxando o banco do appsettings
            var mongoDatabase = mongoClient.GetDatabase(fichaService.Value.DatabaseName);

            _fichaCollection = mongoDatabase.GetCollection<Ficha>(databaseService.Value.FichaCollectionName);
        }

    }
}
