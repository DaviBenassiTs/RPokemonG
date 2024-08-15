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

        public async Task<List<Ficha>> GetAsync() =>
            await _fichaCollection.Find(x => true).ToListAsync();
        public async Task<Ficha> GetAsync(string id) =>
            await _fichaCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync (Ficha ficha) =>
            await _fichaCollection.InsertOneAsync(ficha);
        public async Task UpdateAsync (string id, Ficha ficha) =>
            await _fichaCollection.ReplaceOneAsync(x => x.Id == id, ficha);
        public async Task RemoveAsync(string id) => 
            await _fichaCollection.DeleteOneAsync(x => x.Id == id);
        //criando os metodos api

    }
}
