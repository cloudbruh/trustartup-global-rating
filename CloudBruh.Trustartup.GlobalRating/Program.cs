using CloudBruh.Trustartup.GlobalRating;
using CloudBruh.Trustartup.GlobalRating.Models.RawDtos;
using Microsoft.Extensions.Configuration;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

var feedContentSystemUrl = config.GetValue<string>("Settings:FeedContentSystemUrl");
var ratingCalculationSystemUrl = config.GetValue<string>("Settings:RatingCalculationSystemUrl");

var retriever = new Retriever(feedContentSystemUrl);

IReadOnlyDictionary<long, StartupRawDto> startups = await retriever.GetStartups();
IReadOnlyDictionary<long, PostRawDto> posts = await retriever.GetPosts();
IReadOnlyDictionary<long, CommentRawDto> comment = await retriever.GetComments();
IReadOnlyDictionary<long, FollowRawDto> follows = await retriever.GetFollows();
IReadOnlyDictionary<long, LikeRawDto> likes = await retriever.GetLikes();

Console.WriteLine("Done");
