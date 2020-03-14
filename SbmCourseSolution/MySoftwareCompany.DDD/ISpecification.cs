using System;
using System.Linq.Expressions;

namespace MySoftwareCompany.DDD
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
    }
}
