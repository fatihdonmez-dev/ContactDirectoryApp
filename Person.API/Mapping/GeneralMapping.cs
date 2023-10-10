using AutoMapper;
using MongoDB.Driver.Core.Misc;
using Person.API.Dtos;
using Person.API.Models;

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
