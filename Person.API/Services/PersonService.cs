using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Person.API.Dtos;
using Person.API.Settings;

namespace Person.API.Services
{
    public class PersonService : IPersonService
    {
        private readonly IMongoCollection<Models.Person> _personCollection;
        private readonly IMapper _mapper;

        public PersonService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _personCollection = database.GetCollection<Models.Person>(databaseSettings.CollectionName);
            _mapper = mapper;
        }

        public async Task<List<PersonDto>> GetAllAsync()
        {
            var persons = await _personCollection.Find<Models.Person>(p=> true).ToListAsync();
            if(!persons.Any())
            {
                persons = new List<Models.Person> { };
            }

            return _mapper.Map<List<PersonDto>>(persons);
        }

        public async Task<PersonDto> CreateAsync(PersonCreateDto personCreateDto)
        {
            var newPerson = _mapper.Map<Models.Person>(personCreateDto);
            await _personCollection.InsertOneAsync(newPerson);

            return _mapper.Map<PersonDto>(newPerson);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _personCollection.DeleteOneAsync(x => x.Id == id);

           return result.DeletedCount > 0 ? true : false;
        }

    }
}
