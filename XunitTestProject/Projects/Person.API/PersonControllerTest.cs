using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Person.API.Controllers;
using Person.API.Dtos;
using Person.API.Enums;
using Person.API.Models;
using Person.API.Services;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace XunitTestProject.Projects.Person.API
{
    public class PersonControllerTest
    {
        private readonly HttpClient _client;

        public PersonControllerTest()
        {
            // API'nizin adresini buraya ekleyin
            _client = new HttpClient { BaseAddress = new Uri("http://localhost:5231") };
        }

        [Fact]
        public async Task GetPersonsTest_ShouldReturnOk()
        {
            // Arrange: Test için gerekli hazýrlýklar

            // Act: API endpointini çaðýr
            var response = await _client.GetAsync("/api/persons");

            // Assert: Yanýtý kontrol et
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetPersonsTest_ShouldReturnNotFound()
        {
            // Arrange: Test için gerekli hazýrlýklar

            // Act: Mevcut olmayan bir endpoint'i çaðýr
            var response = await _client.GetAsync("/api/persons/12");


            // Assert: Yanýtý kontrol et
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task PostEndpoint_ShouldAddData()
        {
            // Arrange: Gönderilecek veri örneði
            var newPerson = new PersonCreateDto()
            {
                FirstName = "Fatih",
                LastName = "Dönmez",
                Company = "Test Cmp",
                ContactInfo = new List<ContactInfoDto>
                {
                    new ContactInfoDto
                    {
                        InfoType = InfoType.PhoneNumber,
                        InfoContent = "5554567"
                    },
                    new ContactInfoDto
                    {
                        InfoType = InfoType.Email,
                        InfoContent = "sample@example.com"
                    }
                }
            };

            // JSON formatýna dönüþtür
            var jsonData = JsonSerializer.Serialize<PersonCreateDto>(newPerson);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Act: POST isteði gönder
            var response = await _client.PostAsync("/api/persons", content);

            // Assert: Yanýtý kontrol et
            Assert.Equal(HttpStatusCode.OK, response.StatusCode); // HTTP 201 Created olmalý
        }
    }
}