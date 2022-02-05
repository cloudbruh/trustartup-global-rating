using CloudBruh.Trustartup.GlobalRating;
using CloudBruh.Trustartup.GlobalRating.Models;
using Microsoft.Extensions.Configuration;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

var feedContentSystemUrl = config.GetValue<string>("Settings:FeedContentSystemUrl");
var ratingCalculationSystemUrl = config.GetValue<string>("Settings:RatingCalculationSystemUrl");

var retriever = new Retriever(feedContentSystemUrl, ratingCalculationSystemUrl);

IReadOnlyDictionary<long, StartupRawDto> startups = await retriever.GetStartups();

Console.WriteLine("Done");
