using MediatR;

namespace Modules.NewsLetter.Application.Articles.CreateArticle;

public sealed record CreateArticleCommand(string Title, string Summary, string Content) : IRequest<Guid>;
