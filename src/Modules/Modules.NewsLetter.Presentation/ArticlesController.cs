using MediatR;
using Microsoft.AspNetCore.Mvc;
using Modules.NewsLetter.Application.Articles.CreateArticle;
using Modules.NewsLetter.Application.Articles.GetArticleById;

namespace Presentation;

[ApiController]
[Route("api/newsletter/[controller]")]
public class ArticlesController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateArticleRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateArticleCommand(request.Title, request.Summary, request.Content);
        var articleId = await sender.Send(command, cancellationToken);
        // nameof(GetById)
        return CreatedAtAction(nameof(GetById), new { id = articleId }, null);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetArticleByIdQuery(id);
        var article = await sender.Send(query, cancellationToken);
        if (article is null)
        {
            return NotFound();
        }

        return Ok(article);
    }

    public sealed record CreateArticleRequest(string Title, string Summary, string Content);
}