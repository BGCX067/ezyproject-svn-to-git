// -----------------------------------------------------------------------
// <copyright file="UtilitiesTests.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------


using G4.Core.Util;

namespace FrameworkUnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections;


    [TestClass]
    public class UtilitiesTests
    {
        [TestMethod]
        public void CONVERT_TO_BOOLEAN_FROM_STRING()
        {
            string test = "true";
            bool val = ConverterUtil.GetTFromString<bool>(test);
            Assert.IsTrue(val);
        }

        [TestMethod]
        public void GENERATE_UNIQUE_STRING_1_MILLON()
        {
            Hashtable ht = new Hashtable();

            for (int i = 0; i < 1000000; i++)
            {
                ht.Add(StringUtil.GetUniqueKey(), 1);
            }

            Assert.AreEqual(1000000, ht.Count);
        }

        [TestMethod]
        public void GENERATE_UNIQUE_ID_2_MILLON()
        {
            Hashtable ht = new Hashtable();

            for (int i = 0; i < 2000000; i++)
            {
                ht.Add(StringUtil.GenerateId(), 1);
            }

            Assert.AreEqual(2000000, ht.Count);
        }
    }
}
