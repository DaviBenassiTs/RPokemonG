using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace RPokemonG.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; private set; } //private pra conseguir apenas colocar as informações pelo construtor
        [StringLength(16, ErrorMessage = "Name length can't be more than 16.", MinimumLength = 4)]
        public string Nome { get; private set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; private set; }
        [DataType(DataType.Password)]
        public string Senha { get; private set; } 
    }
}
