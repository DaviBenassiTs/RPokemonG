using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RPokemonG.Models
{
    public class Especie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Nome { get; set; }
        public string Vida { get; set; }
        public int Qi { get; set; }
        public int Velocidade { get; set; }
        public int Forca { get; set; }

    }
}
