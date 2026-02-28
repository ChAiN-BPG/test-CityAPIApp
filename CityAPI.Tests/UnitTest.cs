using CityApiApp.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Text.Json;

namespace CityAPI.Tests;

public class CityControllerIntegrationTest : IClassFixture<WebApplicationFactory<Program>> {
    private readonly HttpClient _client;

    public CityControllerIntegrationTest(WebApplicationFactory<Program> factory) {
        _client = factory.CreateClient();
    }
    [Fact]
    public async Task Test_GetCityList() {
        var response = await _client.GetAsync("city");
        Console.WriteLine($"Status: {response.StatusCode}");
        // Assert - HTTP level
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        // Assert - Body level
        var json = await response.Content.ReadAsStringAsync();
        var cities = JsonSerializer.Deserialize<List<CityDataResponseModel>>(json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        Assert.NotNull(cities);
        Assert.True(cities.Count == 10);         

    }

    [Fact]
    public async Task Test_GetCityList_WithSearch() {

        var response = await _client.GetAsync("city?CityName=Azadshahr");
        Console.WriteLine($"Status: {response.StatusCode}");
        // Assert - HTTP level
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        // Assert - Body level
        var json = await response.Content.ReadAsStringAsync();
        var cities = JsonSerializer.Deserialize<List<CityDataResponseModel>>(json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        Assert.NotNull(cities);
        Assert.True(cities.Count == 1);
    }
}
