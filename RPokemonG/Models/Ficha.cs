using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RPokemonG.Models
{
    public class Ficha
    {
        [BsonId]//define que é a chave primária
        [BsonRepresentation(BsonType.ObjectId)]//define que vai ser um id gerado pelo banco
        public string? Id { get; set; }
        [BsonElement("Nome")]//nome da coluna no banco
        public string Nome { get; set; }
        public string Elemento { get; set; }
        public string Especie { get; set; }
        public int Nivel { get; set; }

    }
}
