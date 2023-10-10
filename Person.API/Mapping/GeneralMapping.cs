using AutoMapper;
using Person.API.Dtos;

namespace Person.API.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Models.Person, PersonDto>().ReverseMap();
            CreateMap<Models.Person, PersonCreateDto>().ReverseMap();

            CreateMap<Models.ContactInfo, ContactInfoDto>().ReverseMap();
        }
    }
}
