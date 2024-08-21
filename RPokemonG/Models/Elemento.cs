using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RPokemonG.Models
{
    public class Elemento
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Nome { get; set; }
        [BsonElement("Atk1")]
        public string Ataque1 {  get; set; }
        [BsonElement("Atk2")]
        public string Ataque2 { get; set; }
        [BsonElement("Atk3")]
        public string Ataque3 { get; set; }
    }
}
