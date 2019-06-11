using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace g_mvc.Models
{
    public class Room
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("City")]
        public string City { get; set; }
        
        [BsonElement("RoomCount")]
        public int RoomCount { get; set; }
        
        [BsonElement("Square")]
        public int Square { get; set; }
        
        [BsonElement("OwnerFullName")]
        public string OwnerFullName { get; set; }

        [BsonElement("OwnerPhone")]
        public string OwnerPhone { get; set; }
    }
}