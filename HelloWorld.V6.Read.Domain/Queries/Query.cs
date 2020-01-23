

namespace HelloWorld.V6.Read.Domain.Queries
{
    public abstract class Query<TResult>
    {
        public TResult Result { get; set; }
    }
}
