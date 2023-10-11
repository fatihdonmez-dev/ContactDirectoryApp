using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using static Report.API.Helper.Enums;

namespace Report.API.Models
{
    public class Report
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }
        public string Location { get; set; }
        public int RegisteredPersonCount { get; set; }
        public int PhoneCount { get; set; }
        public DateTime ReportDate { get; set; }
        public ReportStatusType Status { get; set; }
    }
}
