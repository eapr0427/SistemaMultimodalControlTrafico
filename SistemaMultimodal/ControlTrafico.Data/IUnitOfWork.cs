using System;
using System.Collections.Generic;
using System.Text;

namespace ControlTrafico.Data
{
    public interface IUnitOfWork
    {
        void CommitChanges();
        void RollbackChanges();
    }
}
