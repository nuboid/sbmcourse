using MySoftwareCompany.DDD;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace MyApplication.Infrastructure.Repositories.JsonFiles
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected string _fileDirectory;
        public BaseRepository(string fileDirectory)
        {
            _fileDirectory = fileDirectory;
        }
        public T Add(T entity)
        {
            var json = JsonSerializer.Serialize<T>(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T GetById(string Id)
        {
            //return _domainDbContext.Set<T>().SingleOrDefault(e => e.Id == Id);
            return null;
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
