using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseHR.Tests
{
    [TestClass]
    public class DBUtilsTests
    {
        OleDbConnection correct_connection = DBUtils.CreateConnection("MSOLEDBSQL.1", "DESKTOP-OK3BIT4", "SSPI", "HRD");

        [TestMethod]
        public void create_connection_correct_test()
        {
            //arrange
            OleDbConnection test_connection = DBUtils.CreateConnection("MSOLEDBSQL.1", "DESKTOP-OK3BIT4", "SSPI", "HRD");
            //act
            test_connection.Open();
            //assert
            Assert.AreEqual(test_connection.State.ToString(), "Open");
        }

        [TestMethod]
        [ExpectedException(typeof(System.Data.OleDb.OleDbException))]
        public void create_connection_wrong_test()
        {
            //arrange
            OleDbConnection test_connection = DBUtils.CreateConnection("MSOLEDBSQL.1", "DESKTOP", "SSPI", "Storage");
            //act
            test_connection.Open();
            //assert - Expect exception
        }

        [TestMethod]
        [ExpectedException(typeof(System.Data.OleDb.OleDbException))]
        public void Execute_wrong_command_test()
        {
            //arrange
            string wrongCommand = "wrong command";
            //act
            DBUtils.ExecuteCommand(wrongCommand);
            //assert - Expect exception
        }

        [TestMethod]
        [ExpectedException(typeof(System.Data.OleDb.OleDbException))]
        public void Execute_wrong_connection_test()
        {
            //arrange
            string wrongCommand = "command";
            OleDbConnection wrong_connection = DBUtils.CreateConnection("MSOLEDBSQL.1", "DESKTOP", "SSPI", "Storage");
            //act
            DBUtils.ExecuteCommand(wrongCommand);
            //assert - Expect exception (timeout)
        }

        [TestMethod]
        public void countRows_correct_test()
        {
            //arrange
            string countBy = "requestTypeId";
            string table = "requestTypeTable";
            //act
            int result = DBUtils.countRows(countBy, table);
            //assert
            Assert.AreEqual(result, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Data.OleDb.OleDbException))]
        public void countRows_incorrect_values_test()
        {
            //arrange
            string countBy = "qwertt";
            string table = "qwerty";
            //act
            int result = DBUtils.countRows(countBy, table);
            //assert - Expect exception
        }
    }
}
