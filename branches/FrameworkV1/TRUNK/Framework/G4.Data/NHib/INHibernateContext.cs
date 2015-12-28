namespace G4.Data.NHib
{
    public interface INHibernateContext
    {
        INHibernateUnitOfWork CreateUnitOfWork();
    }
}