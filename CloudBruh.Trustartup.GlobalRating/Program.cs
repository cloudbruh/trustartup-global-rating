using System.Net.Http.Json;
using CloudBruh.Trustartup.GlobalRating;
using CloudBruh.Trustartup.GlobalRating.Models;
using CloudBruh.Trustartup.GlobalRating.Models.RawDtos;
using Microsoft.Extensions.Configuration;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

var feedContentSystemUrl = config.GetValue<string>("Settings:FeedContentSystemUrl");
var ratingCalculationSystemUrl = config.GetValue<string>("Settings:RatingCalculationSystemUrl");

var retriever = new Retriever(feedContentSystemUrl);

IReadOnlyList<StartupRawDto> startups = await retriever.GetStartups();
IReadOnlyList<PostRawDto> posts = await retriever.GetPosts();
IReadOnlyList<CommentRawDto> comments = await retriever.GetComments();
IReadOnlyList<FollowRawDto> follows = await retriever.GetFollows();
IReadOnlyList<LikeRawDto> likes = await retriever.GetLikes();

List<Startup> result = new Converter(startups, posts, comments, likes, follows).GetConvertedStartups().ToList();

// string serialized = JsonSerializer.Serialize(result[0], new JsonSerializerOptions() {WriteIndented = true});
// Console.WriteLine(serialized);

using (var client = new HttpClient())
{
    HttpResponseMessage ratingResult = await client.PostAsJsonAsync($"{ratingCalculationSystemUrl}/global", result[0]);

    Console.WriteLine(await ratingResult.Content.ReadAsStringAsync());
}

Console.WriteLine("Done");
