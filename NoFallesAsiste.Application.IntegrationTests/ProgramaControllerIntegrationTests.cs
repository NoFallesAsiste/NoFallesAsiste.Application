using NoFallesAsiste.Application;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace NoFallesAsiste.Application.IntegrationTests
{
    public class ProgramaControllerIntegrationTests : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private readonly HttpClient _client;
        public ProgramaControllerIntegrationTests(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }
        [Fact]
        public async Task Index_WhenCalled_ReturnsApplicationForm()
        {
            var response = await _client.GetAsync("/Programas");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("Analisis y Desarrollo de sistemas de informacion", responseString);
            Assert.Contains("Analisis y Desarrollo de software", responseString);
        }
        [Fact]
        public async Task Create_WhenCalled_ReturnsCreateForm()
        {
            var response = await _client.GetAsync("/Programas/Create");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("Programa", responseString);
        }
        [Fact]
        public async Task Create_SentWrongModel_ReturnsViewWithErrorMessages()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Programas/Create");
            var formModel = new Dictionary<string, string>
                {
                    { "Description", "Sin descripcion" },
                    { "Version", "3" },
                    { "TypeProgramId", "2" }
                };
            postRequest.Content = new FormUrlEncodedContent(formModel);
            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("Nombre del programa requerido", responseString);
        }
        [Fact]
        public async Task Create_WhenPOSTExecuted_ReturnsToIndexViewWithCreatedPrograma()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Programas/Create");
            var formModel = new Dictionary<string, string>
            {
                { "Name", "Nuevo Programa" },
                { "Description", "Sin descripcion" },
                { "Version", "3" },
                { "TypeProgramId", "2" }
            };
            postRequest.Content = new FormUrlEncodedContent(formModel);
            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("Nuevo Programa", responseString);
            Assert.Contains("Sin descripcion", responseString);
        }
    }
}