using MyApplication.Infrastructure.EntityFramework;
using MySoftwareCompany.DDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyApplication.Infrastructure.Repositories.EntityFramework
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected DomainDbContext _domainDbContext;
        public BaseRepository(DomainDbContext domainDbContext)
        {
            _domainDbContext = domainDbContext;
        }
        public T Add(T entity)
        {
            _domainDbContext.Set<T>().Add(entity);
            _domainDbContext.SaveChanges();

            return entity;
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T GetById(string Id)
        {
            return _domainDbContext.Set<T>().SingleOrDefault(e => e.Id == Id);
        }

        public List<T> List(ISpecification<T> spec = null)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
