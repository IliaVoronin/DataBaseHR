using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataBaseHR.Tests
{
    [TestClass]
    public class LoginFormTest
    {
        [TestMethod]
        public void LoginButton_nodata()
        {
            //arrange
            string login = "";
            string password = "";
            LoginForm loginForm = new LoginForm();
            //act
            string result = loginForm.loginButton_logic(login, password);
            //assert
            Assert.AreEqual(result, "Enter login and password");
        }

        [TestMethod]
        public void LoginButton_nopassword()
        {
            //arrange
            string login = "login";
            string password = "";
            LoginForm loginForm = new LoginForm();
            //act
            string result = loginForm.loginButton_logic(login, password);
            //assert
            Assert.AreEqual(result, "Enter login and password");
        }

        [TestMethod]
        public void LoginButton_nologin()
        {
            //arrange
            string login = "";
            string password = "password";
            LoginForm loginForm = new LoginForm();
            //act
            string result = loginForm.loginButton_logic(login, password);
            //assert
            Assert.AreEqual(result, "Enter login and password");
        }

        [TestMethod]
        public void LoginButton_user_undefined()
        {
            //arrange
            string login = "fakeuser";
            string password = "fakepassword";
            LoginForm loginForm = new LoginForm();
            //act
            string result = loginForm.loginButton_logic(login, password);
            //assert
            Assert.AreEqual(result, "User is undefined!");
        }

        [TestMethod]
        public void LoginButton_login_successfull()
        {
            //arrange
            string login = "hr";
            string password = "12345";
            LoginForm loginForm = new LoginForm();
            //act
            string result = loginForm.loginButton_logic(login, password);
            //assert
            Assert.AreEqual(result, "Login successfull");
        }
    }
}
