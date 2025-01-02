namespace Blog.Contracts.Articles;

public record CreateArticleResponse(
    Guid Id,
    string Title,
    string AuthorName,
    string Subtitle,
    string Content,
    string CoverImage,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    List<TagResponse> Tags,
    int CommentsCount,
    int ReactionsCount
);

public record TagResponse(Guid Id);
