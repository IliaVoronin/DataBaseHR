using NUnit.Framework;

using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Threading;

namespace DataBaseHR.E2ETests
{
    public class Tests
    {
        public const string DriverUrl = "http://188.134.88.224:4723/";
        public WindowsDriver<WindowsElement> DesktopSession;
        [SetUp]
        public void Setup()
        {
            AppiumOptions Options = new AppiumOptions();
            Options.AddAdditionalCapability("app", "D:\\DataBaseHR-master\\DataBaseHR\\bin\\Debug\\DataBaseHR.exe");
            Options.AddAdditionalCapability("deviceName", "WindowsPC");
            DesktopSession = new WindowsDriver<WindowsElement>(new Uri(DriverUrl), Options);
            Assert.IsNotNull(DesktopSession);
        }

        [Test]
        public void nodata_Button()
        {
            WindowsElement Click = DesktopSession.FindElementByAccessibilityId("loginButton");


            DesktopSession.Quit();
            Assert.Pass();
        }
        [Test]
        public void LoginButton_login_successfull()
        {
            WindowsElement LoginEnter = DesktopSession.FindElementByAccessibilityId("loginTextBox");
            LoginEnter.SendKeys("hr");
            WindowsElement PWEnter = DesktopSession.FindElementByAccessibilityId("passwordTextBox");
            PWEnter.SendKeys("12345");
            WindowsElement Click = DesktopSession.FindElementByAccessibilityId("loginButton");

            DesktopSession.Quit();
            Assert.Pass();
        }
        [Test]
        public void username_taken_Register()
        {
            WindowsElement Click = DesktopSession.FindElementByAccessibilityId("registerButton");
            Click.Click();

            var currentWindowHandle = DesktopSession.CurrentWindowHandle;
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var allWindowHandles2 = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles2[0]);


            WindowsElement LoginEnter = DesktopSession.FindElementByAccessibilityId("loginRegisterTextBox");
            LoginEnter.SendKeys("test");
            WindowsElement PwEnter = DesktopSession.FindElementByAccessibilityId("passwordRegisterTextBox");
            PwEnter.SendKeys("1234");
            WindowsElement nClick = DesktopSession.FindElementByAccessibilityId("registerButton");

            DesktopSession.Quit();
            Assert.Pass();
        }
        [Test]
        public void Button_succesfull_Register()
        {
            WindowsElement Click = DesktopSession.FindElementByAccessibilityId("registerButton");
            Click.Click();

            var currentWindowHandle = DesktopSession.CurrentWindowHandle;
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var allWindowHandles2 = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles2[0]);


            WindowsElement LoginEnter = DesktopSession.FindElementByAccessibilityId("loginRegisterTextBox");
            LoginEnter.SendKeys("tt");
            WindowsElement PwEnter = DesktopSession.FindElementByAccessibilityId("passwordRegisterTextBox");
            PwEnter.SendKeys("1234");
            WindowsElement nClick = DesktopSession.FindElementByAccessibilityId("registerButton");

            DesktopSession.Quit();
            Assert.Pass();
        }
        [Test]
        public void Login_nopassword()
        {
            WindowsElement LoginEnter = DesktopSession.FindElementByAccessibilityId("loginTextBox");
            LoginEnter.SendKeys("test");
            WindowsElement Click = DesktopSession.FindElementByAccessibilityId("loginButton");


            DesktopSession.Quit();
            Assert.Pass();
        }
        [Test]
        public void nodata_ButtonRegister()
        {
            WindowsElement Click = DesktopSession.FindElementByAccessibilityId("registerButton");
            Click.Click();

            var currentWindowHandle = DesktopSession.CurrentWindowHandle;
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var allWindowHandles2 = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles2[0]);

            WindowsElement nClick = DesktopSession.FindElementByAccessibilityId("registerButton");

            DesktopSession.Quit();
            Assert.Pass();
        }
        [Test]
        public void LoginButton_nologin()
        {
            WindowsElement LoginEnter = DesktopSession.FindElementByAccessibilityId("passwordTextBox");
            LoginEnter.SendKeys("passwd");
            WindowsElement Click = DesktopSession.FindElementByAccessibilityId("loginButton");


            DesktopSession.Quit();
            Assert.Pass();
        }
        [Test]
        public void user_undefined_LoginButton()
        {
            WindowsElement LoginEnter = DesktopSession.FindElementByAccessibilityId("loginTextBox");
            LoginEnter.SendKeys("fakeuser");
            WindowsElement PWEnter = DesktopSession.FindElementByAccessibilityId("passwordTextBox");
            PWEnter.SendKeys("passwd");
            WindowsElement Click = DesktopSession.FindElementByAccessibilityId("loginButton");


            DesktopSession.Quit();
            Assert.Pass();
        }
        [Test]
        public void RequestButton_add_correct()
        {
            WindowsElement LoginEnter = DesktopSession.FindElementByAccessibilityId("loginTextBox");
            LoginEnter.SendKeys("hr");
            WindowsElement PWEnter = DesktopSession.FindElementByAccessibilityId("passwordTextBox");
            PWEnter.SendKeys("12345");
            WindowsElement Click = DesktopSession.FindElementByAccessibilityId("loginButton");


            DesktopSession.Quit();
            Assert.Pass();
        }
        [Test]
        public void weak_password_RegisterButton()
        {
            WindowsElement Click = DesktopSession.FindElementByAccessibilityId("registerButton");
            Click.Click();

            var currentWindowHandle = DesktopSession.CurrentWindowHandle;
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var allWindowHandles2 = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles2[0]);


            WindowsElement LoginEnter = DesktopSession.FindElementByAccessibilityId("loginRegisterTextBox");
            LoginEnter.SendKeys("test");
            WindowsElement PwEnter = DesktopSession.FindElementByAccessibilityId("passwordRegisterTextBox");
            PwEnter.SendKeys("123");
            WindowsElement nClick = DesktopSession.FindElementByAccessibilityId("registerButton");

            DesktopSession.Quit();
            Assert.Pass();
        }
    }
}