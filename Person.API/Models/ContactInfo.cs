using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using Person.API.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Person.API.Models
{
    public class ContactInfo
    {
        public InfoType InfoType { get; set; }
        public string InfoContent { get; set; }
    }
}
