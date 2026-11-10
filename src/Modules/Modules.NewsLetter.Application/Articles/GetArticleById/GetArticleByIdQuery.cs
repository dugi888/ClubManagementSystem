using MediatR;
using Modules.NewsLetter.Application.DTOs;

namespace Modules.NewsLetter.Application.Articles.GetArticleById;

public sealed record GetArticleByIdQuery(Guid Id) : IRequest<ArticleDto?>;