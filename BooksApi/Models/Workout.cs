using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WorkoutApi.Models
{
    public class Workout
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string WorkoutName { get; set; }

        [BsonElement("Time")]
        public decimal Time { get; set; }

        [BsonElement("Category")]
        public string Category { get; set; }

        [BsonElement("Intensity")]
        public string Intensity { get; set; }
    }
}