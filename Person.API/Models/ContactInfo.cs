using Person.API.Enums;

namespace Person.API.Models
{
    public class ContactInfo
    {
        public Guid Id { get; set; }
        public InfoType InfoType { get; set; }
        public string InfoContent { get; set; }
    }
}
