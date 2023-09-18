using CoffeeBrowser.Library.Data;
using System.Net.Http.Json;

namespace CoffeeBrowser.Maui.Data;

public class CoffeeService : ICoffeeService
{
    private readonly HttpClient _httpClient = new();

    public async Task<IEnumerable<Coffee>?> LoadCoffeeAsync()
    {
        var coffees = await _httpClient.GetFromJsonAsync<IEnumerable<Coffee>>(
            "http://www.thomasclaudiushuber.com/pluralsight/coffees.json");

        // Simulate some server work
        await Task.Delay(50);

        return coffees;
    }
}
