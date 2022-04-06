using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace User.API.Entities
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
