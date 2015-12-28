using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using G4.Data.NHib;
using G4.Core.Infrastructure;
using NHibernate;
using G4.Data.NHDataProvider;

namespace FrameworkDemo
{
    interface IUserAccountRepository
    {

    }

    /*
    public class UserAccountRepository<int, UserAccount2> : NHRepository<int, UserAccount2>, IUserAccountRepository where T : class, IEntityKey<TKey>
    {
        public UserAccountRepository(ISession session):base(session)
        {

        }
    }
     * */

    public class UserAccountRepository : NHRepository<int, UserAccount2>, IUserAccountRepository
    {
        public UserAccountRepository(ISession session) : base(session)
        {

        }


        public IList<UserAccount2> GetAllWithDeleted()
        {
            return this.All().ToList();
        }
    }
}
