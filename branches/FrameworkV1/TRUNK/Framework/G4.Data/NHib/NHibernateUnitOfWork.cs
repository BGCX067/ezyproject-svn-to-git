using System;
using NHibernate;

namespace G4.Data.NHib
{
    public class NHibernateUnitOfWork : INHibernateUnitOfWork
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly ITransaction _transaction;
        public ISession Session { get; private set; }

        public NHibernateUnitOfWork(ISessionFactory sessionFactory)
        {
            this._sessionFactory = sessionFactory;
            this.Session = this._sessionFactory.OpenSession();
            this._transaction = this.SetupNewSession();
            this.Session.FlushMode = FlushMode.Auto;
        }

        private ITransaction SetupNewSession()
        {
            if (this._transaction != null)
                this._transaction.Dispose();

            return this.Session.BeginTransaction();
        }

        public void RollBack()
        {
            if (this._transaction != null && this._transaction.IsActive)
                this._transaction.Rollback();
        }

        public void Commit()
        {
            if (this._transaction.IsActive)
                this._transaction.Commit();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.Session != null)
                {
                    this.Session.Dispose();
                    this.Session = null;
                }
            }
        }

        ~NHibernateUnitOfWork()
        {
            this.Dispose(true);
        }
    }
}