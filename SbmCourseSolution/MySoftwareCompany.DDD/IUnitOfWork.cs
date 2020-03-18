using System;
using System.Collections.Generic;
using System.Text;

namespace MySoftwareCompany.DDD
{
    public interface IUnitOfWork
    {
        void Start();
        void Commit();
        void RollBack();
    }
}
