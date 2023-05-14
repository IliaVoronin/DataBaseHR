using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.OleDb;

namespace DataBaseHR.Int_Tests
{
    [TestClass]
    public class IntTests
    {
        OleDbConnection connection = DBUtils.CreateConnectionTest();

        [TestMethod]
        public void SelectDatatableTest() //Проверяем правильно ли считываются таблицы с БД
        {
            string name = "Ivan";
            string surname = "Guivan";
            string sex = "M";
            string mail = "ivan@gmail.com";
            string date = "04.03.1999";
            string country = "Russia";
            int postid = 3;
            int userid = 2;
            WorkerForm workerForm = new WorkerForm(userid, postid);

            workerForm.saveButton_logic(name, surname, sex, mail, date, country, userid);
            var infoTable = DBUtils.Select(String.Format("SELECT * FROM infoTable WHERE infoUserId = {0}", userid));
            string resultName = (string)infoTable[0][2];
            string resultSurname = (string)infoTable[0][3];
            string resultSex = (string)infoTable[0][4];
            string resultEmail = (string)infoTable[0][5];

            Assert.AreEqual(name, resultName);
            Assert.AreEqual(surname, resultSurname);
            Assert.AreEqual(sex, resultSex);
            Assert.AreEqual(mail, resultEmail);
        }

        [TestMethod]
        public void ExecuteCommandTest() //Проверяем правиьлно ли выполняется SQL запрос
        {
            string postName = "test";
            string postSalary = "1234";
            HRForm hrform = new HRForm();
            int count = DBUtils.countRows("postId", "postTable");

            hrform.addPostButton_logic(postName, postSalary);

            Assert.AreEqual(count + 1, DBUtils.countRows("postId", "postTable"));
            DBUtils.ExecuteCommand("DELETE FROM postTable WHERE postId=(SELECT MAX(postId) FROM postTable)");
        }

        [TestMethod]
        public void CheckForLoginTrueTest()
        {
            Assert.IsTrue(DBUtils.CheckForLogin("hr"));
        }

        [TestMethod]
        public void CheckForLoginFalseTest()
        {
            Assert.IsFalse(DBUtils.CheckForLogin("asdhkjhbsd"));
        }

        [TestMethod]
        public void CheckViewTest() //Проверяем кол-во ролей
        {
            Assert.AreEqual(3, DBUtils.countRows("groupId","groupTable"));
        }

        [TestMethod]
        public void InsertRowTest()  //Проверяем правильность вставки строки
        {
            int postId = 1;
            int num = 9;
            HRForm hrform = new HRForm();
            int count = DBUtils.countRows("vacancyPostId", "vacancyTable");

            hrform.addVacancyButton_logic(postId.ToString(), num.ToString());

            Assert.AreEqual(count + 1, DBUtils.countRows("vacancyPostId", "vacancyTable"));
            DBUtils.ExecuteCommand("DELETE FROM vacancyTable WHERE vacancyPostId=1");
        }

        [TestMethod]
        public void DeleteRowTest()  //Проверяем правильность удаления строки
        {
            int userId = 2;
            string requestType = "2";
            DateTime testTime = DateTime.Today;
            MakeRequestForm requestForm = new MakeRequestForm(userId);
           
            requestForm.requestButton_logic(userId, requestType, testTime);
            int count = DBUtils.countRows("requestId", "requestTable");
            requestForm.deleteRow(count);

            Assert.AreEqual(count, DBUtils.countRows("requestId", "requestTable"));
            DBUtils.ExecuteCommand("DELETE FROM requestTable WHERE requestId=(SELECT MAX(requestId) FROM requestTable)");
        }

        [TestMethod]
        public void RowChangeTest()  //Проверяем правильность изменения строки
        {
            int postId = 1;
            HRForm hrform = new HRForm();

            var value1 = DBUtils.Select(String.Format("SELECT postSalary FROM postTable WHERE postId = {0}", postId));
            hrform.changePostButton_logic("1111", postId);
            var value2 = DBUtils.Select(String.Format("SELECT postSalary FROM postTable WHERE postId = {0}", postId));

            Assert.AreNotEqual(value1[0][0], value2[0][0]);
            hrform.changePostButton_logic("0", postId);
        }

        [TestMethod]
        public void create_connection_correct_test()
        {
            //arrange
            //OleDbConnection test_connection = DBUtils.CreateConnection("MSOLEDBSQL.1", "DESKTOP-OK3BIT4", "SSPI", "HRD");
            OleDbConnection test_connection = DBUtils.CreateConnectionTest();
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
            OleDbConnection test_connection = DBUtils.CreateConnection("MSOLEDBSQL.1", "DESKTOP", "SSPI", "FAKE");
            //act
            test_connection.Open();
            //assert - Expect exception
        }
    }
}
