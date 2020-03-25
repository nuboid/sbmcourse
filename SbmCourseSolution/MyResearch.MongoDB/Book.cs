using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace MyResearch.MongoDB
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string BookName { get; set; }

        public double Price { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }
    }
}
