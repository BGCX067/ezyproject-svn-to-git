using NHibernate;

namespace G4Framework.Data.Nhibernate
{
    public abstract class NHibContext
    {
        protected ISessionFactory SessionFactory { get; set; }

        public NHibUnitOfWork CreateUnitOfWork()
        {
            return new NHibUnitOfWork(SessionFactory.OpenSession());
        }
    }
}