using MediatR;

namespace Modules.NewsLetter.Application.Contracts;

public interface IQuery<out TResult> : IRequest<TResult>
{
}