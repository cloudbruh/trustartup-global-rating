using System.Text.Json;
using CloudBruh.Trustartup.GlobalRating.Models;
using CloudBruh.Trustartup.GlobalRating.Models.RawDtos;

namespace CloudBruh.Trustartup.GlobalRating;

public class Retriever
{
    private readonly string _feedContentSystemUrl;

    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public Retriever(string feedContentSystemUrl)
    {
        _feedContentSystemUrl = feedContentSystemUrl;
    }
    
    public async Task<IReadOnlyList<StartupRawDto>> GetStartups()
    {
        using var client = new HttpClient();

        Task<Stream> response = client.GetStreamAsync($"{_feedContentSystemUrl}/api/startup/?count=-1");

        return await DeserializeInput<StartupRawDto>(await response);
    }
    
    public async Task<IReadOnlyList<PostRawDto>> GetPosts()
    {
        using var client = new HttpClient();

        Task<Stream> response = client.GetStreamAsync($"{_feedContentSystemUrl}/api/post/");

        return await DeserializeInput<PostRawDto>(await response);
    }
    
    public async Task<IReadOnlyList<CommentRawDto>> GetComments()
    {
        using var client = new HttpClient();

        Task<Stream> response = client.GetStreamAsync($"{_feedContentSystemUrl}/api/comment/");

        return await DeserializeInput<CommentRawDto>(await response);
    }
    
    public async Task<IReadOnlyList<FollowRawDto>> GetFollows()
    {
        using var client = new HttpClient();

        Task<Stream> response = client.GetStreamAsync($"{_feedContentSystemUrl}/api/follow/");

        return await DeserializeInput<FollowRawDto>(await response);
    }
    
    public async Task<IReadOnlyList<LikeRawDto>> GetLikes()
    {
        using var client = new HttpClient();

        Task<Stream> response = client.GetStreamAsync($"{_feedContentSystemUrl}/api/like/");

        return await DeserializeInput<LikeRawDto>(await response);
    }

    private static async Task<IReadOnlyList<T>> DeserializeInput<T>(Stream response) where T : IIdentifiable
    {
        return (await JsonSerializer.DeserializeAsync<IEnumerable<T>>(response, SerializerOptions))?.ToList()
               ?? new List<T>();
    }
}