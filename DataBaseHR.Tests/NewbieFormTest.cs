using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataBaseHR.Tests
{
    [TestClass]
    public class NewbieFormTest
    {
        [TestMethod]
        public void SaveButton_successfull()
        {
            //arrange
            string name = "Nika";
            string surname = "Simonova";
            string sex = "F";
            string mail = "test@gmail.com";
            string date = "04.04.04";
            string country = "USA";
            int postid = 2;
            int userid = 3;
            NewbieForm newbieForm = new NewbieForm(userid);
            //act
            newbieForm.saveButton_logic(name, surname, sex, mail, date, country, postid, userid);
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
        public void SaveButton_no_info()
        {
            //arrange
            string name = "";
            string surname = "";
            string sex = "";
            string mail = "";
            string date = "";
            string country = "";
            int postid = 2;
            int userid = 3;
            NewbieForm newbieForm = new NewbieForm(userid);
            //act 
            string result = newbieForm.saveButton_logic(name, surname, sex, mail, date, country, postid, userid);
            //assert
            Assert.AreEqual(result, "Fill info");
        }

        [TestMethod]
        public void SaveButton_updated()
        {
            //arrange
            string name = "Nika";
            string surname = "Simonova";
            string sex = "F";
            string mail = "test@gmail.com";
            string date = "04.04.04";
            string country = "USA";
            int postid = 2;
            int userid = 3;
            NewbieForm newbieForm = new NewbieForm(userid);
            //act
            string result = newbieForm.saveButton_logic(name, surname, sex, mail, date, country, postid, userid);
            //assert
            Assert.AreEqual(result, "Updated");
        }

        [TestMethod]
        public void GetName_test()
        {
            //arrange
            int userid = 2;
            NewbieForm newbieForm = new NewbieForm(userid);
            //act
            string result = newbieForm.getName(userid);
            //assert
            Assert.AreEqual(result, "Ivan");
        }

        [TestMethod]
        public void GetSurname_test()
        {
            //arrange
            int userid = 2;
            NewbieForm newbieForm = new NewbieForm(userid);
            //act
            string result = newbieForm.getSurname(userid);
            //assert
            Assert.AreEqual(result, "Guivan");
        }

        [TestMethod]
        public void GetSex_test()
        {
            //arrange
            int userid = 2;
            NewbieForm newbieForm = new NewbieForm(userid);
            //act
            string result = newbieForm.getSex(userid);
            //assert
            Assert.AreEqual(result, "M");
        }

        [TestMethod]
        public void GetMail_test()
        {
            //arrange
            int userid = 2;
            NewbieForm newbieForm = new NewbieForm(userid);
            //act
            string result = newbieForm.getMail(userid);
            //assert
            Assert.AreEqual(result, "ivan@gmail.com");
        }

        [TestMethod]
        public void GetDate_test()
        {
            //arrange
            int userid = 2;
            NewbieForm newbieForm = new NewbieForm(userid);
            //act
            string result = newbieForm.getDate(userid);
            //assert
            Assert.AreEqual(result, "04.03.1999");
        }

        [TestMethod]
        public void GetCountry_test()
        {
            //arrange
            int userid = 2;
            NewbieForm newbieForm = new NewbieForm(userid);
            //act
            string result = newbieForm.getCountry(userid);
            //assert
            Assert.AreEqual(result, "Russia");
        }

        [TestMethod]
        public void GetPost_test()
        {
            //arrange
            int userid = 2;
            NewbieForm newbieForm = new NewbieForm(userid);
            //act
            int result = newbieForm.getPost(userid);
            //assert
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void CurrentUserId_incorrect()
        {
            //arrange
            int userid = -1;
            NewbieForm newbieForm = new NewbieForm(userid);
            //act
            string result = newbieForm.getName(userid);
            //assert - Expect exception
        }
    }
}
