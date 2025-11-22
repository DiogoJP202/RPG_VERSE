using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ecommerce.Models
{
    public class Produto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Nome")]
        public string Nome { get; set; }

        [BsonElement("Preco")]
        public decimal Preco { get; set; }

        [BsonElement("Descricao")]
        public string Descricao { get; set; }

        internal async Task<List<Produto>> ToList()
        {
            throw new NotImplementedException();
        }
    }
}
