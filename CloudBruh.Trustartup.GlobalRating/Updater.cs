using System.Net.Http.Json;
using System.Text.Json;
using CloudBruh.Trustartup.GlobalRating.Models;

namespace CloudBruh.Trustartup.GlobalRating;

public class Updater
{
    private readonly string _feedContentSystemUrl;
    
    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public Updater(string feedContentSystemUrl)
    {
        _feedContentSystemUrl = feedContentSystemUrl;
    }

    public async Task UpdateStartup(StartupRating rating)
    {
        using var client = new HttpClient();

        await client.PutAsJsonAsync($"{_feedContentSystemUrl}/api/startup/{rating.Id}/rating", rating, SerializerOptions);
    }
}