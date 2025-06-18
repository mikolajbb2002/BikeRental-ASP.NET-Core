using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

public class KlienciIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public KlienciIntegrationTest(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task ListaKlientow()
    {
        var response = await _client.GetAsync("/Klienci");
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        
        var content = await response.Content.ReadAsStringAsync();
        Assert.Contains("Imie", content); 
    }
}