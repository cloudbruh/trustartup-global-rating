using System.Text.Json;
using CloudBruh.Trustartup.GlobalRating.Models;
using CloudBruh.Trustartup.GlobalRating.Models.RawDtos;

namespace CloudBruh.Trustartup.GlobalRating;

public class Retriever
{
    private readonly string _feedContentSystemUrl;

    public Retriever(string feedContentSystemUrl)
    {
        _feedContentSystemUrl = feedContentSystemUrl;
    }
    
    public async Task<IReadOnlyDictionary<long, StartupRawDto>> GetStartups()
    {
        using var client = new HttpClient();

        Task<Stream> response = client.GetStreamAsync($"{_feedContentSystemUrl}/api/startup/");

        return await DeserializeInput<StartupRawDto>(await response);
    }
    
    public async Task<IReadOnlyDictionary<long, PostRawDto>> GetPosts()
    {
        using var client = new HttpClient();

        Task<Stream> response = client.GetStreamAsync($"{_feedContentSystemUrl}/api/post/");

        return await DeserializeInput<PostRawDto>(await response);
    }
    
    public async Task<IReadOnlyDictionary<long, CommentRawDto>> GetComments()
    {
        using var client = new HttpClient();

        Task<Stream> response = client.GetStreamAsync($"{_feedContentSystemUrl}/api/comment/");

        return await DeserializeInput<CommentRawDto>(await response);
    }
    
    public async Task<IReadOnlyDictionary<long, FollowRawDto>> GetFollows()
    {
        using var client = new HttpClient();

        Task<Stream> response = client.GetStreamAsync($"{_feedContentSystemUrl}/api/follow/");

        return await DeserializeInput<FollowRawDto>(await response);
    }
    
    public async Task<IReadOnlyDictionary<long, LikeRawDto>> GetLikes()
    {
        using var client = new HttpClient();

        Task<Stream> response = client.GetStreamAsync($"{_feedContentSystemUrl}/api/like/");

        return await DeserializeInput<LikeRawDto>(await response);
    }

    private static async Task<IReadOnlyDictionary<long, T>> DeserializeInput<T>(Stream response) where T : IIdentifiable
    {
        IEnumerable<T> enumerable = await JsonSerializer.DeserializeAsync<IEnumerable<T>>(response) ?? Array.Empty<T>();
        return new Dictionary<long, T>(enumerable.Select(item => new KeyValuePair<long, T>(item.Id, item)));
    }
}