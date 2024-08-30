using MongoDB.Driver;
using RPokemonG.Models;
using Microsoft.Extensions.Options;

namespace RPokemonG.Services
{
    public class UserServices
    {
        private readonly IMongoCollection<Users> _users;

        public UserServices(IOptions<DatabaseSettings> mongoDBSettings)
        {
            var client = new MongoClient(mongoDBSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _users = database.GetCollection<Users>(mongoDBSettings.Value.UsersCollectionName);
        }

        public Users GetByName(string username) =>
            _users.Find<Users>(user => user.Nome == username).FirstOrDefault();

        public Users Post(Users user)
        {
            _users.InsertOne(user);
            return user;
        }
    }
}