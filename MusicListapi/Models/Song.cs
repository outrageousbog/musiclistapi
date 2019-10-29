using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace MusicListapi.Models
{
    public class Song
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonElement("Name")] 
        [JsonProperty("name")]
        public string Name { get; set; }

        [BsonElement("Artist")]
        [JsonProperty("artist")]
        public string Artist { get; set; }
        
        [BsonElement("State")]
        [JsonProperty("state")]
        public State State { get; set; }
    }
}