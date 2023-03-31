using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataBaseHR.Tests
{
    [TestClass]
    public class WorkerFormTests
    {
        [TestMethod]
        public void Save_info_no_data()
        {
            //arrange
            string name = "";
            string surname = "";
            string sex = "";
            string mail = "";
            string date = "";
            string country = "";
            int postid = 3;
            int userid = 2;
            WorkerForm workerForm = new WorkerForm(userid, postid);
            //act 
            string result = workerForm.saveButton_logic(name, surname, sex, mail, date, country, userid);
            //assert
            Assert.AreEqual(result, "Fill info");
        }

        [TestMethod]
        public void Save_info_Updated()
        {
            //arrange
            string name = "Ivan";
            string surname = "Guivan";
            string sex = "M";
            string mail = "ivan@gmail.com";
            string date = "04.03.1999";
            string country = "Russia";
            int postid = 3;
            int userid = 2;
            WorkerForm workerForm = new WorkerForm(userid, postid);
            //act
            string result = workerForm.saveButton_logic(name, surname, sex, mail, date, country, userid);
            //assert
            Assert.AreEqual(result, "Updated");
        }

        [TestMethod]
        public void Save_info_successfull()
        {
            //arrange
            string name = "Ivan";
            string surname = "Guivan";
            string sex = "M";
            string mail = "ivan@gmail.com";
            string date = "04.03.1999";
            string country = "Russia";
            int postid = 3;
            int userid = 2;
            WorkerForm workerForm = new WorkerForm(userid, postid);
            //act
            workerForm.saveButton_logic(name, surname, sex, mail, date, country, userid);
            var infoTable = DBUtils.Select(String.Format("SELECT * FROM infoTable WHERE infoUserId = {0}", userid));
            string resultName = (string)infoTable[0][2];
            string resultSurname = (string)infoTable[0][3];
            string resultSex = (string)infoTable[0][4];
            string resultEmail = (string)infoTable[0][5];
            //assert
            Assert.AreEqual(name, resultName);
            Assert.AreEqual(surname, resultSurname);
            Assert.AreEqual(sex, resultSex);
            Assert.AreEqual(mail, resultEmail);
        }

        [TestMethod]
        public void Worker_GetName_test()
        {
            //arrange
            int userid = 2;
            int postid = 3;
            WorkerForm workerForm = new WorkerForm(userid, postid);
            //act
            string result = workerForm.getName(userid);
            //assert
            Assert.AreEqual(result, "Ivan");
        }

        [TestMethod]
        public void Worker_GetSurname_test()
        {
            //arrange
            int userid = 2;
            int postid = 3;
            WorkerForm workerForm = new WorkerForm(userid, postid);
            //act
            string result = workerForm.getSurname(userid);
            //assert
            Assert.AreEqual(result, "Guivan");
        }

        [TestMethod]
        public void Worker_GetSex_test()
        {
            //arrange
            int userid = 2;
            int postid = 3;
            WorkerForm workerForm = new WorkerForm(userid, postid); ;
            //act
            string result = workerForm.getSex(userid);
            //assert
            Assert.AreEqual(result, "M");
        }

        [TestMethod]
        public void Worker_GetMail_test()
        {
            //arrange
            int userid = 2;
            int postid = 3;
            WorkerForm workerForm = new WorkerForm(userid, postid);
            //act
            string result = workerForm.getMail(userid);
            //assert
            Assert.AreEqual(result, "ivan@gmail.com");
        }

        [TestMethod]
        public void Worker_GetDate_test()
        {
            //arrange
            int userid = 2;
            int postid = 3;
            WorkerForm workerForm = new WorkerForm(userid, postid);
            //act
            string result = workerForm.getDate(userid);
            //assert
            Assert.AreEqual(result, "04.03.1999");
        }

        [TestMethod]
        public void Worker_GetCountry_test()
        {
            //arrange
            int userid = 2;
            int postid = 3;
            WorkerForm workerForm = new WorkerForm(userid, postid);
            //act
            string result = workerForm.getCountry(userid);
            //assert
            Assert.AreEqual(result, "Russia");
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void Worker_CurrentUserId_incorrect()
        {
            //arrange
            int userid = -1;
            int postid = 3;
            WorkerForm workerForm = new WorkerForm(userid, postid);
            //act
            string result = workerForm.getName(userid);
            //assert - Expect exception
        }
    }
}
