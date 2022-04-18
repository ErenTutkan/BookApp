using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbTransaction _transaction;

        public UnitOfWork(IDbTransaction transaction)
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
    }
}
