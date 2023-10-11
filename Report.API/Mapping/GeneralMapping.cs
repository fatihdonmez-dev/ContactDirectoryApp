using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection;
using AutoMapper;
using Report.API.Dtos;

namespace Report.API.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Models.Report, RaportDto>().ReverseMap();
        }
    }
}
