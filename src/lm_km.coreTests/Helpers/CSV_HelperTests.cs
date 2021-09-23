using Microsoft.VisualStudio.TestTools.UnitTesting;
using lm_km.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lm_km.core.Tests
{
    [TestClass()]
    public class CSV_HelperTests
    {
        [TestMethod()]
        public void WriteCSVFileTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ReadCSVFileTest()
        {

            string path = @"C:\Users\Luka-Stroj\Downloads\KEYNOTES_TE AWA MANSHED.txt";
            List < Keynote > keynotes = CSV_Helper.ReadCSVFile(path);
            Assert.AreEqual(path, path);
        }
    }
}