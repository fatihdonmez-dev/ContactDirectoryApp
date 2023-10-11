using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Person.API.Controllers;
using Person.API.Dtos;
using Person.API.Enums;
using Person.API.Models;
using Person.API.Services;
using Report.API.Dtos;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace XunitTestProject.Projects.Report.API
{
    public class ReportControllerTest
    {
        private readonly HttpClient _client;

        public ReportControllerTest()
        {
            // API'nizin adresini buraya ekleyin
            _client = new HttpClient { BaseAddress = new Uri("http://localhost:5259") };
        }

        [Fact]
        public async Task GetReportTest_ShouldReturnOk()
        {
            // Arrange: Test i�in gerekli haz�rl�klar

            // Act: API endpointini �a��r
            var response = await _client.GetAsync("/api/reports");

            // Assert: Yan�t� kontrol et
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetReportByIdTest_ShouldReturnOk()
        {
            // Arrange: Test i�in gerekli haz�rl�klar

            // Act: API endpointini �a��r
            var response = await _client.GetAsync("/api/reports/1");

            // Assert: Yan�t� kontrol et
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetReportsTest_ShouldReturnNotFound()
        {
            // Arrange: Test i�in gerekli haz�rl�klar

            // Act: Mevcut olmayan bir endpoint'i �a��r
            var response = await _client.GetAsync("/api/reports/fxfxfxx");


            // Assert: Yan�t� kontrol et
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task SuspendEndpoint_ShouldSendData()
        {
            // Arrange: G�nderilecek veri �rne�i
            var newRequest = new ReportRequestDto()
            {
                Location = "Antalya"
            };

            // JSON format�na d�n��t�r
            var jsonData = JsonSerializer.Serialize<ReportRequestDto>(newRequest);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Act: POST iste�i g�nder
            var response = await _client.PostAsync("/api/reports", content);

            // Assert: Yan�t� kontrol et
            Assert.Equal(HttpStatusCode.OK, response.StatusCode); // HTTP 201 Created olmal�
        }
    }
}