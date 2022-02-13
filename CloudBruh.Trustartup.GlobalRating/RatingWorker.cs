using System.Net.Http.Json;
using System.Text.Json;
using CloudBruh.Trustartup.GlobalRating.Models;

namespace CloudBruh.Trustartup.GlobalRating;

public class RatingWorker
{
    private readonly string _ratingCalculationSystemUrl;

    private readonly Updater _updater;
    
    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public RatingWorker(string ratingCalculationSystemUrl, Updater updater)
    {
        _ratingCalculationSystemUrl = ratingCalculationSystemUrl;
        _updater = updater;
    }

    public async Task Run(List<Startup> startups)
    {
        foreach (Startup startup in startups)
        {
            StartupRating? rating = await GetStartupRating(startup);

            if (rating == null)
            {
                continue;
            }

            await _updater.UpdateStartup(rating);
        }
    }

    private async Task<StartupRating?> GetStartupRating(Startup startup)
    {
        using var client = new HttpClient();
        HttpResponseMessage ratingResult =
            await client.PostAsJsonAsync($"{_ratingCalculationSystemUrl}/global", startup);

        Console.WriteLine(await ratingResult.Content.ReadAsStringAsync());

        return await JsonSerializer.DeserializeAsync<StartupRating>(
            await ratingResult.Content.ReadAsStreamAsync(), SerializerOptions);
    }
}