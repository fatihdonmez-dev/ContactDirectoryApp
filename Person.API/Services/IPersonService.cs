using Person.API.Dtos;

namespace Person.API.Services
{
    public interface IPersonService
    {
        Task<List<PersonDto>> GetAllAsync();
        Task<PersonDto> CreateAsync(PersonCreateDto personCreateDto);
    }
}
