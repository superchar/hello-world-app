

using HelloWorld.V6.Read.Domain.Queries;
using System.Threading.Tasks;

namespace HelloWorld.V6.Read.Domain.Handlers
{
    public interface IQueryHandler<TQuery,TResult> where TQuery : Query<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
