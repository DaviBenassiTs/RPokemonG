using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace RPokemonG.Models
{
    public class Users
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } //private pra conseguir apenas colocar as informações pelo construtor
        [StringLength(16, ErrorMessage = "Name length can't be more than 16.")]
        public string Nome { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [BsonElement("PasswordHash")]
        public string PasswordHash { get; set; }
        public bool IsAdmin { get; set; }
    }
}