using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace WorkoutApi.Models
{
    public class Event
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        [BsonElement("Title")]
        public string title { get; set; }

        [BsonElement("Start")]
        public BsonDateTime Start { get; set; }

        [BsonElement("Colors")]
        [BsonDictionaryOptions(DictionaryRepresentation.Document)]
        public Dictionary<string, string> colors { get; set; }
    }
}