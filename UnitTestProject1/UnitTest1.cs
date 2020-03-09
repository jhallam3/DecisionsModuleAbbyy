using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test2()
        {
            TestMethod1();
        }
        public static async System.Threading.Tasks.Task<List<string>> TestMethod1()
        {

            var appid = "";
            var pwd = "";

            var url = "https://cloud.ocrsdk.com";

            var A = new Abbyy.AbbyyClass();
            var aa = A.Auth(url, appid, pwd);
            var f =  A.AbbyyRunnerAsync(aa, @"C:\code\Adult1 - OUT 22Mar20.pdf");
            return f.Result;
        }
       
    }
}
