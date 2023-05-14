using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataBaseHR.Tests
{
[TestClass]
    public class DatabaseTests
    {
        private const string ConnectionString = "Data Source=(localdb)\\MyLocalDB;Initial Catalog=TestDB;Integrated Security=True";

        [TestMethod]
        public void TestDatabaseConnection()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                Assert.AreEqual(ConnectionState.Open, connection.State);
            }
        }
    }

}
