using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RPokemonG.Models;

namespace RPokemonG.Services
{
    public class EspecieServices
    {
        private readonly IMongoCollection<Especie> _especieCollection;//somente leitura - puxa a tabela e crio o nome

        public EspecieServices(IOptions<DatabaseSettings> especieService)//Configura database
        {
            var mongoClient = new MongoClient(especieService.Value.ConnectionString);//puxando o banco do appsettings
            var mongoDatabase = mongoClient.GetDatabase(especieService.Value.DatabaseName);

            _especieCollection = mongoDatabase.GetCollection<Especie>(especieService.Value.EspecieCollectionName);
        }

        public async Task<List<Especie>> GetEspecie() =>
            await _especieCollection.Find(x => true).ToListAsync();
        public async Task<Especie> GetEspecie(string id) =>
            await _especieCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateEspecie(Especie especie) =>
            await _especieCollection.InsertOneAsync(especie);
        public async Task UpdateEspecie(string id, Especie especie) =>
            await _especieCollection.ReplaceOneAsync(x => x.Id == id, especie);
        public async Task RemoveEspecie(string id) => 
            await _especieCollection.DeleteOneAsync(x => x.Id == id);
        //criando os metodos api

    }
}
