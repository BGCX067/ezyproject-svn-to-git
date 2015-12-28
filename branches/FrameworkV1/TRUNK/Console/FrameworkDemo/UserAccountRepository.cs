using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using G4.Data.NHib;

namespace FrameworkDemo
{
    //public class UserAccountRepository : G4Framework.Data.Nhibernate.NHibRepository<UserAccount>
    //{
    //    //public UserAccountRepository(NHibContext context) : base(context)
    //    //{
            
    //    //}

        
    //}

    public class UserAccountRepository2 : NHibernateRepository<UserAccount>
    {
        
    }

    //public class UserAccountRepository3 : G4.Data.NHib.NHibernateRepository<UserAccount>
    //{

    //}
}
