using AnalaizerClassLibrary;
using ErrorLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AnalaizerClassTests
{
    [TestClass]
    public class AnalaizerClassTests
    {
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"C:\Tests\Lab1\AnalizerLibraryTests\testData.xml", "data", DataAccessMethod.Sequential)]
        //[DataSource(@"Provider=Microsoft.SqlServerCe.Client.4.0; Data Source=C:\Tests\Lab1\dbTests\dbTests.mdf;", "TestData")]
        //[DataSource("System.Data.SqlClient", @"Data Source=DESKTOP-E07JQ8M;AttachDbFilename=C:\Tests\Lab1\dbTests\dbTests.mdf;Integrated Security=True;Connect Timeout=5", "TestData", DataAccessMethod.Sequential)]
        [TestMethod]
        public void Analizer_Format_FromDB()
        {
            string expression = Convert.ToString(TestContext.DataRow["expression"]);
            string error = Convert.ToString(TestContext.DataRow["error"]);
            int position = Convert.ToInt32(TestContext.DataRow["position"]);

            AnalaizerClass.expression = expression;
            string result = AnalaizerClass.Format();

            if (position == -1)
            {
                Assert.AreEqual("&" + error, result);
            }
            else
            {
                Assert.AreEqual("&" + ErrorsExpression.GetFullStringError(error, position), result);
            }
        }
    }
}


