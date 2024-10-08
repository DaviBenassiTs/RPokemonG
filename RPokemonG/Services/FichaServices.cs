﻿using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RPokemonG.Models;

namespace RPokemonG.Services
{
    public class FichaServices
    {
        private readonly IMongoCollection<Ficha> _fichaCollection;//somente leitura - puxa a tabela e crio o nome

        public FichaServices(IOptions<DatabaseSettings> fichaService)//Configura database
        {
            var mongoClient = new MongoClient(fichaService.Value.ConnectionString);//puxando o banco do appsettings
            var mongoDatabase = mongoClient.GetDatabase(fichaService.Value.DatabaseName);

            _fichaCollection = mongoDatabase.GetCollection<Ficha>(fichaService.Value.FichaCollectionName);
        }

        public async Task<List<Ficha>> GetFicha() =>
            await _fichaCollection.Find(x => true).ToListAsync();
        public async Task<Ficha> GetFicha(string id) =>
            await _fichaCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateFicha (Ficha ficha) =>
            await _fichaCollection.InsertOneAsync(ficha);
        public async Task UpdateFicha (string id, Ficha ficha) =>
            await _fichaCollection.ReplaceOneAsync(x => x.Id == id, ficha);
        public async Task RemoveFicha(string id) => 
            await _fichaCollection.DeleteOneAsync(x => x.Id == id);
        //criando os metodos api

    }
}
