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
            // Arrange: Test için gerekli hazýrlýklar

            // Act: API endpointini çaðýr
            var response = await _client.GetAsync("/api/reports");

            // Assert: Yanýtý kontrol et
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetReportByIdTest_ShouldReturnOk()
        {
            // Arrange: Test için gerekli hazýrlýklar

            // Act: API endpointini çaðýr
            var response = await _client.GetAsync("/api/reports/1");

            // Assert: Yanýtý kontrol et
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetReportsTest_ShouldReturnNotFound()
        {
            // Arrange: Test için gerekli hazýrlýklar

            // Act: Mevcut olmayan bir endpoint'i çaðýr
            var response = await _client.GetAsync("/api/reports/fxfxfxx");


            // Assert: Yanýtý kontrol et
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task SuspendEndpoint_ShouldSendData()
        {
            // Arrange: Gönderilecek veri örneði
            var newRequest = new ReportRequestDto()
            {
                Location = "Antalya"
            };

            // JSON formatýna dönüþtür
            var jsonData = JsonSerializer.Serialize<ReportRequestDto>(newRequest);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Act: POST isteði gönder
            var response = await _client.PostAsync("/api/reports", content);

            // Assert: Yanýtý kontrol et
            Assert.Equal(HttpStatusCode.OK, response.StatusCode); // HTTP 201 Created olmalý
        }
    }
}