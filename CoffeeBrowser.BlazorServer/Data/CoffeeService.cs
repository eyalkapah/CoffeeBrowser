using CoffeeBrowser.Library.Data;

namespace CoffeeBrowser.BlazorServer.Data;

public class CoffeeService : ICoffeeService
{
    private readonly IHttpClientFactory _factory;

    public CoffeeService(IHttpClientFactory factory)
    {
        _factory = factory;
    }

    public async Task<IEnumerable<Coffee>?> LoadCoffeeAsync()
    {
        using var httpClient = _factory.CreateClient();

        var coffees = await httpClient.GetFromJsonAsync<IEnumerable<Coffee>>(
            "http://www.thomasclaudiushuber.com/pluralsight/coffees.json");

        // Simulate some server work
        await Task.Delay(50);

        return coffees;
    }
}
