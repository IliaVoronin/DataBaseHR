using System;
using System.Data;
using System.Data.OleDb;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataBaseHR.Tests
{
    [TestClass]
    public class RegisterFormTest
    {
        OleDbConnection connection = DBUtils.CreateConnection("MSOLEDBSQL.1", "DESKTOP-OK3BIT4", "SSPI", "HRD");

        [TestMethod]
        public void RegisterButton_nodata()
        {
            //arrange
            string login = "";
            string password = "";
            RegisterForm registerForm = new RegisterForm();
            //act
            string result = registerForm.registerButton_logic(login, password);
            //assert
            Assert.AreEqual(result, "Fill in all forms");
        }

        [TestMethod]
        public void RegisterButton_weak_password()
        {
            //arrange
            string login = "test";
            string password = "123";
            RegisterForm registerForm = new RegisterForm();
            //act
            string result = registerForm.registerButton_logic(login, password);
            //assert
            Assert.AreEqual(result, "Password must contain atleast 4 symbols");
        }

        [TestMethod]
        public void RegisterButton_username_taken()
        {
            //arrange
            string login = "hr";
            string password = "123456";
            RegisterForm registerForm = new RegisterForm();
            //act
            string result = registerForm.registerButton_logic(login, password);
            //assert
            Assert.AreEqual(result, "Username taken");
        }

        [TestMethod]
        public void RegisterButton_succesfull()
        {
            //arrange
            string login = "test";
            string password = "12345";
            RegisterForm registerForm = new RegisterForm();
            //act
            string result = registerForm.registerButton_logic(login, password);
            //assert
            Assert.AreEqual(result, "Regestration succesful");
            DBUtils.ExecuteCommand("DELETE FROM userTable WHERE userId=(SELECT MAX(userId) FROM userTable)");
        }
    }
}
