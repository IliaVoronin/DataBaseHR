using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Data.OleDb;

namespace DataBaseHR.Tests
{
    [TestClass]
    public class MakeRequestFormTests
    {
        OleDbConnection connection = DBUtils.CreateConnection("MSOLEDBSQL.1", "DESKTOP-OK3BIT4", "SSPI", "HRD");

        [TestMethod]
        public void RequestButton_add_correct()
        {
            //arrange
            int userId = 2;
            int count = DBUtils.countRows("requestId", "requestTable");
            string requestType = "2";
            MakeRequestForm requestForm = new MakeRequestForm(userId);
            DateTime testTime = DateTime.Today;
            //act
            requestForm.requestButton_logic(userId, requestType, testTime);
            //assert
            Assert.AreNotEqual(count, DBUtils.countRows("requestId", "requestTable"));
            DBUtils.ExecuteCommand("DELETE FROM requestTable WHERE requestId=(SELECT MAX(requestId) FROM requestTable)", connection);
        }

        [TestMethod]
        public void RequestButton_add_valid_data()
        {
            //arrange
            int userId = 2;
            int count = DBUtils.countRows("requestId", "requestTable");
            string requestType = "2";
            MakeRequestForm requestForm = new MakeRequestForm(userId);
            DateTime testTime = DateTime.Today;
            //act
            string result = requestForm.requestButton_logic(userId, requestType, testTime);
            //assert
            Assert.AreEqual(result, "Request added");
            DBUtils.ExecuteCommand("DELETE FROM requestTable WHERE requestId=(SELECT MAX(requestId) FROM requestTable)", connection);
        }

        [TestMethod]
        public void RequestButton_invalid_data()
        {
            //arrange
            int userId = 2;
            string requestType = "-1";
            MakeRequestForm requestForm = new MakeRequestForm(userId);
            DateTime testTime = DateTime.Today;
            //act
            string result = requestForm.requestButton_logic(userId, requestType, testTime);
            //Assert
            Assert.AreEqual(result, "Invalid data");
        }

        [TestMethod]
        public void DeleteRow_correct()
        {
            //arrange
            int userId = 2;
            string requestType = "2";
            DateTime testTime = DateTime.Today;
            MakeRequestForm requestForm = new MakeRequestForm(userId);
            //act
            requestForm.requestButton_logic(userId, requestType, testTime);
            int count = DBUtils.countRows("requestId", "requestTable");
            requestForm.deleteRow(count);
            //assert
            Assert.AreEqual(count, DBUtils.countRows("requestId", "requestTable"));
            DBUtils.ExecuteCommand("DELETE FROM requestTable WHERE requestId=(SELECT MAX(requestId) FROM requestTable)", connection);
        }

        [TestMethod]
        public void DeleteRow_valid_data()
        {
            //arrange
            int userId = 2;
            string requestType = "2";
            DateTime testTime = DateTime.Today;
            MakeRequestForm requestForm = new MakeRequestForm(userId);
            //act
            requestForm.requestButton_logic(userId, requestType, testTime);
            int count = DBUtils.countRows("requestId", "requestTable");
            string result = requestForm.deleteRow(count);
            //assert
            Assert.AreEqual(result, "Request deleted");
            DBUtils.ExecuteCommand("DELETE FROM requestTable WHERE requestId=" +
                "(SELECT MAX(requestId) FROM requestTable)", connection);
        }

        [TestMethod]
        public void DeleteRow_invalid_data()
        {
            //arrange
            int userId = -1;
            string requestType = "-1";
            DateTime testTime = DateTime.Today;
            MakeRequestForm requestForm = new MakeRequestForm(userId);
            //act
            requestForm.requestButton_logic(userId, requestType, testTime);
            int count = DBUtils.countRows("requestId", "requestTable");
            string result = requestForm.deleteRow(count);
            //assert
            Assert.AreEqual(result, "Invalid data");
            DBUtils.ExecuteCommand("DELETE FROM requestTable WHERE requestId=" +
                "(SELECT MAX(requestId) FROM requestTable)", connection);
        }

        [TestMethod]
        public void GetData_invalid_data()
        {
            //arrange
            int userId = -1;
            MakeRequestForm requestForm = new MakeRequestForm(userId);
            //act
            var testTable = requestForm.getData(userId);
            int result = testTable.Count;
            //assert
            Assert.AreEqual(result, 0);
        }
    }
}
