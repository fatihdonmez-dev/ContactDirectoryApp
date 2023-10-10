using Person.API.Enums;

namespace Person.API.Dtos
{
    public class ContactInfoDto
    {
        public Guid Id { get; set; }
        public InfoType InfoType { get; set; }
        public string InfoContent { get; set; }

    }
}
