using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebApiExample.Domain.Core;

namespace WebApiExample.Data.Core
{
    public interface IReadOnlyRepository<TAggregate, TId> where TAggregate : IAggregateRoot
    {
        TAggregate Find(TId id);

        IEnumerable<TAggregate> FindAll();

        IEnumerable<TAggregate> Find(string query, dynamic filter);
    }
}
