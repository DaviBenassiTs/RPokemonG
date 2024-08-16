using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RPokemonG.Models;

namespace RPokemonG.Services
{
    public class ElementoServices
    {
        private readonly IMongoCollection<Elemento> _elementoCollection;//somente leitura - puxa a tabela e crio o nome

        public ElementoServices(IOptions<DatabaseSettings> elementoService)//Configura database
        {
            var mongoClient = new MongoClient(elementoService.Value.ConnectionString);//puxando o banco do appsettings
            var mongoDatabase = mongoClient.GetDatabase(elementoService.Value.DatabaseName);

            _elementoCollection = mongoDatabase.GetCollection<Elemento>(elementoService.Value.ElementoCollectionName);
        }

        public async Task<List<Elemento>> GetElemento() =>
            await _elementoCollection.Find(x => true).ToListAsync();
        public async Task<Elemento> GetElemento(string id) =>
            await _elementoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateElemento (Elemento elemento) =>
            await _elementoCollection.InsertOneAsync(elemento);
        public async Task UpdateElemento (string id, Elemento elemento) =>
            await _elementoCollection.ReplaceOneAsync(x => x.Id == id, elemento);
        public async Task RemoveElemento(string id) => 
            await _elementoCollection.DeleteOneAsync(x => x.Id == id);
        //criando os metodos api

    }
}
