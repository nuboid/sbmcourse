using Microsoft.EntityFrameworkCore.Storage;
using MySoftwareCompany.DDD;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApplication.Infrastructure.EntityFramework
{
    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _transaction;
        public void SetTransaction(IDbContextTransaction transaction)
        {
            _transaction = transaction;
        }
        public void Commit()
        {
            _transaction.Commit();
        }

        public void RollBack()
        {
            _transaction.Rollback();
        }

        public void Start()
        {
        }
    }
}
