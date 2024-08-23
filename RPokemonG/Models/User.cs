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
        public string Senha { get; private set; } 
    }
}
