namespace Report.API.Dtos
{
    public class PersonDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public List<ContactInfoDto> ContactInfo { get; set; }
    }
}
