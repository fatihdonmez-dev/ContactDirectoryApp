namespace Person.API.Dtos
{
    public class PersonCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public List<ContactInfoDto> ContactInfo { get; set; }
    }

}
