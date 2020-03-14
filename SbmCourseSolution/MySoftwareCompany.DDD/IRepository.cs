using System.Collections.Generic;

namespace MySoftwareCompany.DDD
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(string Id);
        List<T> List(ISpecification<T> spec = null);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
