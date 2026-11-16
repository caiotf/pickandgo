using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace PickAndGo.Tests;

public class ApiEndpointsTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    [Fact]
    public async Task Health_retorna_200()
    {
        var client = factory.CreateClient();

        var response = await client.GetAsync("/health");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task WeatherForecast_responde_no_prefixo_api()
    {
        var client = factory.CreateClient();

        var response = await client.GetAsync("/api/WeatherForecast");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}