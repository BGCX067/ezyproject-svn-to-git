using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using G4.Data.NHib;
using G4.Data.NHDataProvider;

namespace FrameworkDemo
{
    public class UserService
    {
        NHRepository<int, UserAccount2> _repository;
        public UserService(NHRepository<int,UserAccount2> repository)
        {
            _repository = repository;
        }


    }
}
