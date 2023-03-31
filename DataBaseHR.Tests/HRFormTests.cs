using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Data.OleDb;

namespace DataBaseHR.Tests
{
    [TestClass]
    public class HRFormTests
    {

        OleDbConnection connection = DBUtils.CreateConnection("MSOLEDBSQL.1", "DESKTOP-OK3BIT4", "SSPI", "HRD");

        [TestMethod]
        public void AddPost_correct()
        {
            //arrange
            string postName = "test";
            string postSalary = "1234";
            HRForm hrform = new HRForm();
            int count = DBUtils.countRows("postId", "postTable");
            //act
            hrform.addPostButton_logic(postName, postSalary);
            //assert
            Assert.AreEqual(count + 1, DBUtils.countRows("postId", "postTable"));
            DBUtils.ExecuteCommand("DELETE FROM postTable WHERE postId=(SELECT MAX(postId) FROM postTable)", connection);
        }

        [TestMethod]
        public void AddPost_valid_data()
        {
            //arrange
            string postName = "test";
            string postSalary = "1234";
            HRForm hrform = new HRForm();
            int count = DBUtils.countRows("postId", "postTable");
            //act
            string result = hrform.addPostButton_logic(postName, postSalary);
            //assert
            Assert.AreEqual(result, "Post added");
            DBUtils.ExecuteCommand("DELETE FROM postTable WHERE postId=(SELECT MAX(postId) FROM postTable)", connection);
        }

        [TestMethod]
        public void AddPost_invaid_data()
        {
            //arrange
            string postName = "test";
            string postSalary = "test";
            HRForm hrform = new HRForm();
            //act
            string result = hrform.addPostButton_logic(postName, postSalary);
            //assert
            Assert.AreEqual(result, "Invalid data");
        }

        [TestMethod]
        public void Delete_post_correct()
        {
            //arrange
            HRForm hrform = new HRForm();
            string postName = "test";
            string postSalary = "1234";
            hrform.addPostButton_logic(postName, postSalary);
            int count = DBUtils.countRows("postId", "postTable");
            //act
            hrform.deletePostButton_logic(count);
            //assert
            Assert.AreEqual(count, DBUtils.countRows("postId", "postTable"));
            DBUtils.ExecuteCommand("DELETE FROM postTable WHERE postId=(SELECT MAX(postId) FROM postTable)", connection);
        }

        [TestMethod]
        public void ChangePost_correct()
        {
            //arrange
            int postId = 1;
            HRForm hrform = new HRForm();
            //act
            var value1 = DBUtils.Select(String.Format("SELECT postSalary FROM postTable WHERE postId = {0}", postId));
            hrform.changePostButton_logic("1111", postId);
            var value2 = DBUtils.Select(String.Format("SELECT postSalary FROM postTable WHERE postId = {0}", postId));
            //assert
            Assert.AreNotEqual(value1[0][0], value2[0][0]);
            hrform.changePostButton_logic("0", postId);
        }

        [TestMethod]
        public void ChangePost_valid_data()
        {
            //arrange
            int postId = 1;
            HRForm hrform = new HRForm();
            //act
            string result = hrform.changePostButton_logic("0", postId);
            //assert
            Assert.AreEqual(result, "Post changed");
        }

        [TestMethod]
        public void ChangePost_invaid_data()
        {
            //arrange
            int postId = 1;
            HRForm hrform = new HRForm();
            //act
            string result = hrform.changePostButton_logic("test", postId);
            //assert
            Assert.AreEqual(result, "Invalid data");
        }

        [TestMethod]
        public void AddVacancy_correct()
        {
            //arrange
            int postId = 1;
            int num = 9;
            HRForm hrform = new HRForm();
            int count = DBUtils.countRows("vacancyPostId", "vacancyTable");
            //act
            hrform.addVacancyButton_logic(postId.ToString(),num.ToString());
            //assert
            Assert.AreEqual(count + 1, DBUtils.countRows("vacancyPostId", "vacancyTable"));
            DBUtils.ExecuteCommand("DELETE FROM vacancyTable WHERE vacancyPostId=1", connection);
        }

        [TestMethod]
        public void AddVacancy_valid_data()
        {
            //arrange
            int postId = 1;
            int num = 9;
            HRForm hrform = new HRForm();
            int count = DBUtils.countRows("vacancyPostId", "vacancyTable");
            //act
            string result = hrform.addVacancyButton_logic(postId.ToString(), num.ToString());
            //assert
            Assert.AreEqual(result, "Vacancy added");
            DBUtils.ExecuteCommand("DELETE FROM vacancyTable WHERE vacancyPostId=1", connection);
        }

        [TestMethod]
        public void AddVacancy_invalid_data()
        {
            //arrange
            HRForm hrform = new HRForm();
            int count = DBUtils.countRows("vacancyPostId", "vacancyTable");
            //act
            string result = hrform.addVacancyButton_logic("500", "test");
            //assert
            Assert.AreEqual(result, "Invalid data");
            DBUtils.ExecuteCommand("DELETE FROM vacancyTable WHERE vacancyPostId=1", connection);
        }

        [TestMethod]
        public void DeleteVacancy_correct()
        {
            //arrange
            int postId = 1;
            int num = 9;
            HRForm hrform = new HRForm();
            //act
            hrform.addVacancyButton_logic(postId.ToString(), num.ToString());
            int count = DBUtils.countRows("vacancyPostId", "vacancyTable");
            hrform.deleteVacancyRow(postId);
            //assert
            Assert.AreEqual(count - 1, DBUtils.countRows("vacancyPostId", "vacancyTable"));
        }

        [TestMethod]
        public void DeleteRow_correct()
        {
            //arrange
            string login = "test";
            string password = "12345";
            HRForm hrform = new HRForm();
            RegisterForm registerForm = new RegisterForm();
            registerForm.registerButton_logic(login, password);
            int count = DBUtils.countRows("userId","userTable");
            var list = DBUtils.Select("SELECT userId FROM userTable WHERE userId=(SELECT MAX(userId) FROM userTable)");
            int id = Convert.ToInt32(list[0][0]);
            //act
            hrform.deleteRow(id);
            //assert
            Assert.AreEqual(count - 1, DBUtils.countRows("userId", "userTable"));
        }

        [TestMethod]
        public void DeleteRow_valid_data()
        {
            //arrange
            string login = "test";
            string password = "12345";
            HRForm hrform = new HRForm();
            RegisterForm registerForm = new RegisterForm();
            registerForm.registerButton_logic(login, password);
            int count = DBUtils.countRows("userId", "userTable");
            var list = DBUtils.Select("SELECT userId FROM userTable WHERE userId=(SELECT MAX(userId) FROM userTable)");
            int id = Convert.ToInt32(list[0][0]);
            //act
            string result = hrform.deleteRow(id);
            //assert
            Assert.AreEqual(result, "Row deleted");
        }
    }
}
