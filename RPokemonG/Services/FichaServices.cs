using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RPokemonG.Models;

namespace RPokemonG.Services
{
    public class FichaServices
    {
        private readonly IMongoCollection<Ficha> _fichaCollection;//somente leitura - puxa a tabela e crio o nome

        public FichaServices(IOptions<DatabaseSettings> fichaService)//Configurar algumas coisas do bd
        {
            var mongoClient = new MongoClient(fichaService.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(fichaService.Value.DatabaseName);

            _fichaCollection = mongoDatabase.GetCollection<Ficha>(fichaService.Value.FichaCollectionName);
        }

    }
}
