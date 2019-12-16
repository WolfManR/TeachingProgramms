using CodePasswordDLL;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace CodePasswordDLL.Tests
{
    [TestClass]
    public class CodePasswordTests:IDisposable
    {
        [TestInitialize]
        public void TestInitialize()
        {
            Debug.WriteLine($"Test Initialized {DateTime.Now.ToShortTimeString()}");
        }

        [TestCleanup]
        public void TestClenup()
        {
            Debug.WriteLine($"Test Cleanup {DateTime.Now.ToShortTimeString()}");
        }
        [TestMethod]
        public void getCodPassword_abc_bcd()
        {
            // arrange
            string strIn = "abc";
            string strExpected = "bcd";

            // act
            string strActual = CodePassword.getCodPassword(strIn);

            //assert
            Assert.AreEqual(strExpected, strActual);
        }
        [TestMethod()]
        public void getCodPassword_empty_empty()
        {
            // arrange 
            string strIn = "";
            string strExpected = "";

            // act 
            string strActual = CodePassword.getCodPassword(strIn);

            //assert
            Assert.AreEqual(strExpected, strActual);
        }


        [TestMethod(),Description("Must Fail to show message")]
        public void getPassword_bcd_abc()
        {
            // arrange 
            string strIn = "bcd";
            string strExpected = "a4bc";

            // act 
            string strActual = CodePassword.getPassword(strIn);

            //assert
            Assert.AreEqual(strExpected, strActual,"Check Values");
        }
        [TestMethod()]
        public void getPassword_bcd_abc_StringAssert()
        {
            // arrange 
            string strIn = "bcd";
            string strExpected = "abc";

            // act 
            string strActual = CodePassword.getPassword(strIn);

            //assert
            StringAssert.Contains(strExpected, strActual);
        }
        [TestMethod()]
        public void getPassword_empty_empty()
        {
            // arrange 
            string strIn = "";
            string strExpected = "";

            // act 
            string strActual = CodePassword.getPassword(strIn);

            //assert
            Assert.AreEqual(strExpected, strActual);
        }

        public void Dispose()
        {
            Debug.WriteLine($"Dispose {DateTime.Now}");
        }
    }
}
