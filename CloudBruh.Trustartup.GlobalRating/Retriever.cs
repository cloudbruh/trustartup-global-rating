using System.Text.Json;
using CloudBruh.Trustartup.GlobalRating.Models;

namespace CloudBruh.Trustartup.GlobalRating;

public class Retriever
{
    private readonly string _feedContentSystemUrl;
    private readonly string _ratingCalculationSystemUrl;

    public Retriever(string feedContentSystemUrl, string ratingCalculationSystemUrl)
    {
        _feedContentSystemUrl = feedContentSystemUrl;
        _ratingCalculationSystemUrl = ratingCalculationSystemUrl;
    }
    
    public async Task<IReadOnlyDictionary<long, StartupRawDto>> GetStartups()
    {
        using var client = new HttpClient();

        Task<Stream> response = client.GetStreamAsync($"{_feedContentSystemUrl}/api/startup/");

        return await DeserializeInput<StartupRawDto>(await response);
    }

    private static async Task<IReadOnlyDictionary<long, T>> DeserializeInput<T>(Stream response) where T : IIdentifiable
    {
        IEnumerable<T> enumerable = await JsonSerializer.DeserializeAsync<IEnumerable<T>>(response) ?? Array.Empty<T>();
        return new Dictionary<long, T>(enumerable.Select(item => new KeyValuePair<long, T>(item.Id, item)));
    }
}