using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using G4.Core.Infrastructure;
using NHibernate;

namespace G4.Data.NHDataProvider
{
    public class NHUnitOfWork : IUnitOfWork
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly ITransaction _transaction;
        public ISession Session { get; private set; }
        private bool disposed = false;

        #region IUnitOfWork Members

        /// <summary>
        /// Initializes a new instance of the <see cref="NHUnitOfWork"/> class.
        /// </summary>
        /// <param name="sessionFactory">The session factory.</param>
        public NHUnitOfWork(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
            Session = _sessionFactory.OpenSession();            
            Session.FlushMode = FlushMode.Auto;
            _transaction = Session.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
        }

        public void RollBack()
        {
            if (_transaction.IsActive)
                _transaction.Rollback();
        }

        public void Commit()
        {
            if (!_transaction.IsActive)
                throw new InvalidOperationException("Oops! We don't have an active transaction");
            _transaction.Commit();
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue 
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        #endregion

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        /// <remarks>
        /// Dispose(bool disposing) executes in two distinct scenarios.
        /// If disposing equals true, the method has been called directly
        /// or indirectly by a user's code. Managed and unmanaged resources
        /// can be disposed.
        /// If disposing equals false, the method has been called by the 
        /// runtime from inside the finalizer and you should not reference 
        /// other objects. Only unmanaged resources can be disposed.
        /// </remarks>
        private void Dispose(bool disposing)
        {
            if (!disposing)
            {
                if (Session.IsOpen)
                    Session.Close();
            }

            disposed = true;
        }
        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="NHibernateUnitOfWork"/> is reclaimed by garbage collection.
        /// </summary>
        /// <remarks>
        /// This destructor will run only if the Dispose method
        /// does not get called.
        /// It gives your base class the opportunity to finalize.
        /// Do not provide destructors in types derived from this class.
        /// </remarks>
        ~NHUnitOfWork()
        {
            Dispose(false);
        }
    }
}
