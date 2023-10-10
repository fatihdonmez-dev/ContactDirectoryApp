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
            // Arrange: Test i�in gerekli haz�rl�klar

            // Act: API endpointini �a��r
            var response = await _client.GetAsync("/api/persons");

            // Assert: Yan�t� kontrol et
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetPersonsTest_ShouldReturnNotFound()
        {
            // Arrange: Test i�in gerekli haz�rl�klar

            // Act: Mevcut olmayan bir endpoint'i �a��r
            var response = await _client.GetAsync("/api/persons/12");


            // Assert: Yan�t� kontrol et
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task PostEndpoint_ShouldAddData()
        {
            // Arrange: G�nderilecek veri �rne�i
            var newPerson = new PersonCreateDto()
            {
                FirstName = "Fatih",
                LastName = "D�nmez",
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

            // JSON format�na d�n��t�r
            var jsonData = JsonSerializer.Serialize<PersonCreateDto>(newPerson);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Act: POST iste�i g�nder
            var response = await _client.PostAsync("/api/persons", content);

            // Assert: Yan�t� kontrol et
            Assert.Equal(HttpStatusCode.OK, response.StatusCode); // HTTP 201 Created olmal�
        }
    }
}