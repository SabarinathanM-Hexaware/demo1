using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Demo1.Entities.Entities
{
    [BsonIgnoreExtraElements]
    public class Colors
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id  { get; set; }
        public string Name  { get; set; }
        public string Desc  { get; set; }
        
    }

}
