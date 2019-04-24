using System;
using System.Transactions;

namespace Recruiting.Infra.Transactions
{
    public class TransactionManager : IDisposable
    {
        private readonly TransactionScope _transactionScope;

        public TransactionManager(TransactionScopeOption scope = TransactionScopeOption.Required)
        {
            _transactionScope = new TransactionScope(scope);
        }

        public void Dispose()
        {
            _transactionScope.Dispose();
        }

        public void Complete()
        {
            _transactionScope.Complete();
        }
    }
}
