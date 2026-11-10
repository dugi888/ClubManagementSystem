using MediatR;
using System;
using Modules.NewsLetter.Domain;
using Modules.NewsLetter.Domain.Articles;

namespace Modules.NewsLetter.Application.Articles.CreateArticle;

internal sealed class CreateArticleCommandHandler(
    IArticleRepository articlesRepo, 
    IUnitOfWork unitOfWork,
    TimeProvider clock) : IRequestHandler<CreateArticleCommand, Guid>
    {
        public async Task<Guid> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            
            var article =  Article.CreateDraft(request.Title, request.Summary, request.Content, clock.GetUtcNow());
            articlesRepo.Add(article);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return article.Id;
        }
    }