using System;
using NHibernate;

namespace G4.Data.NHib
{
    public class NHibernateUnitOfWork : INHibernateUnitOfWork
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly ITransaction _transaction;
        public ISession Session { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NHibernateUnitOfWork"/> class.
        /// </summary>
        /// <param name="sessionFactory">The session factory.</param>
        public NHibernateUnitOfWork(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
            Session = _sessionFactory.OpenSession();
            _transaction = SetupNewSession();
            Session.FlushMode = FlushMode.Auto;
        }

        /// <summary>
        /// Setups a new Nhibernate session.
        /// </summary>
        /// <returns></returns>
        private ITransaction SetupNewSession()
        {
            if (_transaction != null)
                _transaction.Dispose();

            return Session.BeginTransaction();
        }

        /// <summary>
        /// Rollback the whole transaction.
        /// </summary>
        public void RollBack()
        {
            if (_transaction != null && _transaction.IsActive)
                _transaction.Rollback();
        }

        /// <summary>
        /// Commits this instance.
        /// </summary>
        public void Commit()
        {
            if (_transaction.IsActive)
                _transaction.Commit();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Session != null)
                {
                    Session.Dispose();
                    Session = null;
                }
            }
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="NHibernateUnitOfWork"/> is reclaimed by garbage collection.
        /// </summary>
        ~NHibernateUnitOfWork()
        {
            Dispose(true);
        }
    }
}