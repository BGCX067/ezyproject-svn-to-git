using System;
using G4Framework.Infrastructure;
using NHibernate;

namespace G4Framework.Data.Nhibernate
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly ITransaction _transaction;
        //public ISession Session { get; private set; }
        private ISession _session;

        public UnitOfWork(ISessionFactory sessionFactory)
        {
            this._sessionFactory = sessionFactory;
            this._session = this._sessionFactory.OpenSession();
            this._transaction = SetupNewSession();
            this._session.FlushMode = FlushMode.Auto;            
        }

        private ITransaction SetupNewSession()
        {
            if (_transaction != null)
                _transaction.Dispose();

            return Session.BeginTransaction();
        }

        public void RollBack()
        {
            if(_transaction != null && _transaction.IsActive)
                _transaction.Rollback();
        }

        public void Commit()
        {
            if(_transaction.IsActive)
                _transaction.Commit();
        }

        public ISession Session
        {
            get { return this._session; }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                //if(_transaction != null)
                //{
                //    _transaction.Rollback();
                //    _transaction.Dispose();
                //}

                if(_session != null)
                {
                    _session.Dispose();
                    _session = null;
                }
            }
        }

        ~UnitOfWork()
        {
            Dispose(true);
        }
    }
}