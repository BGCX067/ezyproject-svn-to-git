using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using G4.Core.Infrastructure;
using System.Threading;
namespace FrameworkUnitTests.G4.Core.Test
{
    [TestClass]
    public class SingletonTest
    {
        [TestMethod]
        public void TestGenericSingletonNET40()
        {
            TestData t1 = Singleton<TestData>.Instance;            
            TestData t2 = Singleton<TestData>.Instance;
            //Singleton<TestData> s = new Singleton<TestData>();
            Assert.AreSame(t1, t2);            
        }

        [TestMethod]
        public void TestGenericSingletonNET35()
        {
            TestData t1 = Singleton<TestData>.Instance;
            TestData t2 = Singleton<TestData>.Instance;
            //Singleton<TestData> s = new Singleton<TestData>();
            Assert.AreSame(t1, t2);  
        }
    }

    public class TestData
    {
        public int Id { get; set; }
        public string Data { get; set; }

        public TestData()
        {

        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Id, Data);
        }

    }    
}
