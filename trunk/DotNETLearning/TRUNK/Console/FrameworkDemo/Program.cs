using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using G4.Core.Util;
using G4.Data.NHib;
using StructureMap;
using System.Linq;
using G4.Core.Infrastructure;

namespace FrameworkDemo
{

    class Program
    {
        static void Main(string[] args)
        {
            //ObjectFactory.Initialize(x => x.ForRequestedType<INHibernateContext>().CacheBy(InstanceScope.Hybrid).Use(context => new NHibernateFluentContext(Assembly.GetExecutingAssembly())));
            ObjectFactory.Configure(x => x.AddRegistry<FrameworkRegistry>());
            //ObjectFactory.Initialize(x => x.AddRegistry<FrameworkRegistry>());
            //EngineContext.Initialize(new TestModule());
            //EngineContext.Initialize();
            //AddUserInBatch();

            //QueryWithPagination();

            //AddUserAccountWithDepartmentsInBatch();
            //AddCitys();
            //ObjectFactory.GetInstance<INHibernateContext>().CreateUnitOfWork()
            //NHUnitOfWork uow = new NHUnitOfWork(

            /*
            using (NHUnitOfWork uow = new NHUnitOfWork(new NHibernateFluentContext(Assembly.GetExecutingAssembly()).CreateSessionFactory()))
            {
                try
                {
                    NHRepository<int, UserAccount2> repository = new NHRepository<int, UserAccount2>(uow.Session);
                    repository.Add(new UserAccount2 { Username = "abc" });
                    repository.Add(new UserAccount2 { Username = "abc2" });
                    uow.Commit();
                }
                catch (Exception)
                {
                    uow.RollBack();
                }

            }*/

        }

        private static void AddCitys()
        {
            NHibernateRepository<City> cityRepository = new NHibernateRepository<City>();
            City c = new City()
            {
                Name = "c1",
                Population = 2000000,
                Municipality = new Municipality
                                    {
                                        Name = "M1"
                                    }
            };
            cityRepository.Insert(c);
            cityRepository.Save();
        }

        private static void AddUserAccountWithDepartmentsInBatch()
        {


            NHibernateRepository<Department> dptRepository = new NHibernateRepository<Department>();
            dptRepository.Insert(new Department { DepartmentName = "Department 100" });
            dptRepository.Insert(new Department { DepartmentName = "Department 200" });
            dptRepository.Insert(new Department { DepartmentName = "Department 300" });
            dptRepository.Insert(new Department { DepartmentName = "Department 400" });
            dptRepository.Insert(new Department { DepartmentName = "Department 500" });
            dptRepository.Save();

            List<Department> dpts = dptRepository.All().ToList();

            NHibernateRepository<UserAccount> accountsRepository = new NHibernateRepository<UserAccount>();
            for (int i = 0; i < 5000; i++)
            {
                UserAccount acct = new UserAccount();
                acct.Email = "mscsharp_" + i + "@gmail.com";
                acct.Password = i + "_password";
                acct.Username = "tester_" + i;

                Department rndDpt = dpts[new Random().Next(dpts.Count)];

                //if (i < 100)
                //    acct.Department = dpts.Find(x => x.DepartmentName.Contains("100"));
                //else if (i < 200)
                //    acct.Department = dpts.Find(x => x.DepartmentName.Contains("200"));

                //else if (i < 300)
                //    acct.Department = dpts.Find(x => x.DepartmentName.Contains("300"));

                //else if (i < 400)
                //    acct.Department = dpts.Find(x => x.DepartmentName.Contains("400"));

                //else if (i < 500)
                //    acct.Department = dpts.Find(x => x.DepartmentName.Contains("500"));

                acct.Department = rndDpt;


                accountsRepository.Insert(acct);
            }
            accountsRepository.Save();
        }

        private static void QueryWithPagination()
        {
            NHibernateRepository<UserAccount> accts = new NHibernateRepository<UserAccount>();
            long total;
            var data = accts.Find(x => x.Id > 300, "Username", OrderByDirection.Descending, 2, 10, out total).ToList();

            //var data = accts.All().OrderByDescending(x => x.Email).Skip(0).Take(10).ToList();
            data.ForEach(x => Console.WriteLine(x.ToString()));
        }

        private static void AddUserInBatch()
        {
            UserAccountRepository2 repository2 = new UserAccountRepository2();
            try
            {
                for (int i = 101; i < 5000; i++)
                {
                    UserAccount user2 = new UserAccount { Password = i + "_abc123", Username = "Test" + i, Email = "mscsharp@gmail.com" };
                    repository2.Insert(user2);

                }
                repository2.Save();
            }
            catch (Exception)
            {
            }
        }


        private static void BlockCollectionDemo()
        {
            BlockingCollection<int> bc = new BlockingCollection<int>();

            var producer = Task.Factory.StartNew(() =>
                                                     {
                                                         Random rnd = new Random();
                                                         for (int i = 0; i < 5; i++)
                                                         {
                                                             bc.Add(rnd.Next());
                                                         }
                                                         bc.CompleteAdding();
                                                     });

            var consumer = Task.Factory.StartNew(() =>
                                                     {
                                                         foreach (var item in bc.GetConsumingEnumerable())
                                                         {
                                                             Console.WriteLine(item);
                                                         }
                                                     });

            consumer.Wait();
        }

        private static void OutputUniqueId()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 1000000; i++)
            {
                sb.AppendLine(StringUtil.GenerateId());
            }

            File.WriteAllText("randomIds.log", sb.ToString());
        }

        private static void OutputUniqueKey()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 1000000; i++)
            {
                sb.AppendLine(StringUtil.GetUniqueKey());
            }

            File.WriteAllText("randomKeys.log", sb.ToString());
        }
    }
}
