using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RPokemonG.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; private set; } //private pra conseguir apenas colocar as informações pelo construtor
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public byte[] PasswordHash { get; private set; } //cria um hash da senha para não ter a senha pura no banco
        public byte[] PasswordSalt { get; private set; }

        public User(string nome, string email)
        {
            Nome = nome;    
            Email = email;
        }
        public void EncryptPassword(byte[] passwordHash, byte[] passwordSalt)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }
        private void ValidateDomain()
        {
           
        }
    }
}
