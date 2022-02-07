using CloudBruh.Trustartup.GlobalRating.Models;
using CloudBruh.Trustartup.GlobalRating.Models.RawDtos;

namespace CloudBruh.Trustartup.GlobalRating;

public class Converter
{
    private readonly IReadOnlyList<StartupRawDto> _rawStartups;
    private readonly Dictionary<long, List<PostRawDto>> _rawPostsByStartup;

    private readonly Dictionary<(CommentableType CommentableType, long CommentableId), List<CommentRawDto>>
        _rawCommentsByCommentable;

    private readonly Dictionary<(LikeableType LikeableType, long LikeableId), List<LikeRawDto>> _rawLikesByLikeable;
    private readonly Dictionary<long, List<FollowRawDto>> _rawFollowsByStartup;

    public Converter(
        IReadOnlyList<StartupRawDto> rawStartups,
        IEnumerable<PostRawDto> rawPosts,
        IEnumerable<CommentRawDto> rawComments,
        IEnumerable<LikeRawDto> rawLikes,
        IEnumerable<FollowRawDto> rawFollows)
    {
        _rawStartups = rawStartups;
        _rawPostsByStartup = rawPosts
            .GroupBy(post => post.StartupId)
            .ToDictionary(group => group.Key,
                group => group.ToList());
        _rawCommentsByCommentable = rawComments
            .GroupBy(comment => (comment.CommentableType, comment.CommentableId))
            .ToDictionary(group => group.Key,
                group => group.ToList());
        _rawLikesByLikeable = rawLikes
            .GroupBy(like => (like.LikeableType, like.LikeableId))
            .ToDictionary(group => group.Key, group => group.ToList());
        _rawFollowsByStartup = rawFollows
            .GroupBy(follow => follow.StartupId)
            .ToDictionary(group => group.Key, group => group.ToList());
    }

    public IEnumerable<Startup> GetConvertedStartups()
    {
        return _rawStartups.Select(ConvertStartup);
    }

    private Startup ConvertStartup(StartupRawDto dto)
    {
        _rawPostsByStartup.TryGetValue(dto.Id, out List<PostRawDto>? rawPosts);
        rawPosts ??= new List<PostRawDto>();

        _rawCommentsByCommentable.TryGetValue((CommentableType.Startup, dto.Id), out List<CommentRawDto>? rawComments);
        rawComments ??= new List<CommentRawDto>();

        _rawFollowsByStartup.TryGetValue(dto.Id, out List<FollowRawDto>? rawFollows);
        rawFollows ??= new List<FollowRawDto>();

        _rawLikesByLikeable.TryGetValue((LikeableType.Startup, dto.Id), out List<LikeRawDto>? rawLikes);
        rawLikes ??= new List<LikeRawDto>();

        return new Startup
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            UserId = dto.UserId,
            EndingAt = dto.EndingAt,
            FundsGoal = dto.FundsGoal,
            Rating = dto.Rating,
            Posts = rawPosts.Select(ConvertPost).ToList(),
            Comments = rawComments.Select(ConvertComment).ToList(),
            Follows = rawFollows.Select(ConvertFollow).ToList(),
            Likes = rawLikes.Select(ConvertLike).ToList(),
            UpdatedAt = dto.UpdatedAt,
            CreatedAt = dto.CreatedAt
        };
    }

    private Post ConvertPost(PostRawDto dto)
    {
        _rawCommentsByCommentable.TryGetValue((CommentableType.Post, dto.Id), out List<CommentRawDto>? rawComments);
        rawComments ??= new List<CommentRawDto>();

        _rawLikesByLikeable.TryGetValue((LikeableType.Post, dto.Id), out List<LikeRawDto>? rawLikes);
        rawLikes ??= new List<LikeRawDto>();

        return new Post
        {
            Id = dto.Id,
            StartupId = dto.StartupId,
            Header = dto.Header,
            Text = dto.Text,
            Comments = rawComments.Select(ConvertComment).ToList(),
            Likes = rawLikes.Select(ConvertLike).ToList(),
            UpdatedAt = dto.UpdatedAt,
            CreatedAt = dto.CreatedAt
        };
    }

    private static Comment ConvertComment(CommentRawDto dto)
    {
        return new Comment
        {
            Id = dto.Id,
            UserId = dto.UserId,
            Text = dto.Text,
            RepliedId = dto.RepliedId,
            UpdatedAt = dto.UpdatedAt,
            CreatedAt = dto.CreatedAt
        };
    }

    private static Like ConvertLike(LikeRawDto dto)
    {
        return new Like
        {
            Id = dto.Id,
            UserId = dto.UserId,
            CreatedAt = dto.CreatedAt
        };
    }

    private static Follow ConvertFollow(FollowRawDto dto)
    {
        return new Follow
        {
            Id = dto.Id,
            UserId = dto.UserId,
            StartupId = dto.StartupId,
            CreatedAt = dto.CreatedAt
        };
    }
}