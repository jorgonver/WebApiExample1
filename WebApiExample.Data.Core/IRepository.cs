using WebApiExample.Domain.Core;

namespace WebApiExample.Data.Core
{
    interface IRepository<TAggregate, TId> : IReadOnlyRepository<TAggregate, TId> where TAggregate : IAggregateRoot
    {
        void Update(TAggregate aggregate);
        void Insert(TAggregate aggregate);
        void Delete(TAggregate aggregate);
    }
}
