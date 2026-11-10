namespace Modules.NewsLetter.Application.DTOs;

public sealed record ArticleDto(Guid Id, string Title, string Summary, string Content, string Status, DateTimeOffset CreatedAt, DateTimeOffset? PublishedAt, string CoverImageStorageKey);