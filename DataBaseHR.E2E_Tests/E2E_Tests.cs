using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using Renci.SshNet;
using System;
using System.IO;
using System.Threading;

namespace DataBaseHR.E2ETests
{
    public class Tests
    {
        /*
        public const string DriverUrl = "http://127.0.0.1:4723/";
        public WindowsDriver<WindowsElement> DesktopSession;
        [SetUp]
        public void Setup()
        {
            AppiumOptions Options = new AppiumOptions();
            Options.AddAdditionalCapability("app", "C:\\Users\\admin\\source\\repos\\DataBaseHR\\DataBaseHR\\bin\\Debug\\DataBaseHR.exe");
            Options.AddAdditionalCapability("deviceName", "WindowsPC");
            DesktopSession = new WindowsDriver<WindowsElement>(new Uri(DriverUrl), Options);
            Assert.IsNotNull(DesktopSession);
        }
        */

        public const string DriverUrl = "http://188.134.88.224:4723/";
        public WindowsDriver<WindowsElement> DesktopSession;
        [SetUp]
        public void Setup()
        {
            SftpClient sftpClient = new SftpClient("188.134.88.224:4723", 22, "Walker", "LiMingHao");
            try
            {
                sftpClient.Connect();
                sftpClient.UploadFile(File.Open("D:\\a\\DataBaseHR\\DataBaseHR\\DataBaseHR\\obj\\Debug\\DataBaseHR.exe", FileMode.Open), "DataBaseHR.exe");
                sftpClient.Disconnect();
            }
            catch (Exception)
            {
                sftpClient.Dispose();
            }

            AppiumOptions Options = new AppiumOptions();
            Options.AddAdditionalCapability("app", "C:\\Users\\Walker\\DataBaseHR.exe");
            Options.AddAdditionalCapability("deviceName", "WindowsPC");
            DesktopSession = new WindowsDriver<WindowsElement>(new Uri(DriverUrl), Options);
            Assert.IsNotNull(DesktopSession);
        }

        // Сценарий 1: Пользователь хочет создать аккаунт. Запускает приложение, нажимает на кнопку регистрации,
        // перодит в окно регистрации, вводит логин и пароль, нажимает зарегестрироваться. Совершает попытку входа
        // в систему, вход выполнен. Так же хочет изменить данные о себе, нажимает кнопку "изменить данные",
        // переходит в окно изменения данных, вводит новые данные, нажимает сохранить изменения. Возвращается 
        // на главный экран, видит что данные сохранились. 

        [Test]
        public void Test1_register()
        {
            String testLogin = "test1";
            String testPassword = "12345";

            String testName = "Test Name";
            String testSurname = "Test Surname";
            String testSex = "M";
            String testEmail = "test@gmail.com";
            String testDate = "01.01.2000";
            String testCountry = "Test Country";


            WindowsElement registerButton = DesktopSession.FindElementByAccessibilityId("registerButton");
            registerButton.Click();

            WindowsElement registereLoginTextBox = DesktopSession.FindElementByAccessibilityId("loginRegisterTextBox");
            registereLoginTextBox.SendKeys(testLogin);
            WindowsElement registerPasswordTextBox = DesktopSession.FindElementByAccessibilityId("passwordRegisterTextBox");
            registerPasswordTextBox.SendKeys(testPassword);

            WindowsElement registerButton2 = DesktopSession.FindElementByAccessibilityId("registerButton2");
            registerButton2.Click();

            WindowsElement loginTextBox = DesktopSession.FindElementByAccessibilityId("loginTextBox");
            loginTextBox.SendKeys(testLogin);
            WindowsElement passwordTextBox = DesktopSession.FindElementByAccessibilityId("passwordTextBox");
            passwordTextBox.SendKeys(testPassword);

            var allWindowHandles = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles[0]);

            WindowsElement loginButton = DesktopSession.FindElementByAccessibilityId("loginButton");
            loginButton.Click();

            Thread.Sleep(TimeSpan.FromSeconds(2));

            var allWindowHandles1 = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles1[0]);

            WindowsElement changeInfoButton = DesktopSession.FindElementByAccessibilityId("changeInfoButton");
            changeInfoButton.Click();

            WindowsElement nameBox = DesktopSession.FindElementByAccessibilityId("nameBox");
            nameBox.SendKeys(testName);
            WindowsElement surnameBox = DesktopSession.FindElementByAccessibilityId("surnameBox");
            surnameBox.SendKeys(testSurname);
            WindowsElement sexBox = DesktopSession.FindElementByAccessibilityId("sexBox");
            sexBox.SendKeys(testSex);
            WindowsElement emailBox = DesktopSession.FindElementByAccessibilityId("emailBox");
            emailBox.SendKeys(testEmail);
            WindowsElement dateBox = DesktopSession.FindElementByAccessibilityId("dateBox");
            dateBox.SendKeys(testDate);
            WindowsElement countryBox = DesktopSession.FindElementByAccessibilityId("countryBox");
            countryBox.SendKeys(testCountry);
            WindowsElement postBox = DesktopSession.FindElementByAccessibilityId("postBox");
            postBox.Click();
            postBox.FindElementByName("Уборщик").Click();


            WindowsElement saveButton = DesktopSession.FindElementByAccessibilityId("saveButton");
            saveButton.Click();

            WindowsElement backButton = DesktopSession.FindElementByAccessibilityId("backButton");
            backButton.Click();

            WindowsElement nameLabel = DesktopSession.FindElementByAccessibilityId("nameLabel");
            WindowsElement surnameLabel = DesktopSession.FindElementByAccessibilityId("surnameLabel");
            WindowsElement sexLabel = DesktopSession.FindElementByAccessibilityId("sexLabel");
            WindowsElement emailLabel = DesktopSession.FindElementByAccessibilityId("emailLabel");
            WindowsElement dateLabel = DesktopSession.FindElementByAccessibilityId("dateLabel");
            WindowsElement countryLabel = DesktopSession.FindElementByAccessibilityId("countryLabel");

            Assert.AreEqual(nameLabel.Text, testName);
            Assert.AreEqual(surnameLabel.Text, testSurname);
            Assert.AreEqual(sexLabel.Text, testSex);
            Assert.AreEqual(emailLabel.Text, testEmail);
            Assert.AreEqual(dateLabel.Text, testDate);
            Assert.AreEqual(countryLabel.Text, testCountry);
            DesktopSession.Close();
            DesktopSession.Quit();
        }

        

        // Сценарий 2: Пользователь хочет войти в систему но вводит не правильный пароль, получается соответствующую ошибку,
        // закрывает её, вводит пароль и успешно входит в систему.

        [Test]
        public void Test2_wrong_password()
        {
            String testLogin = "test1";
            String testPassword = "12345";
            String testWrongPassword = "wrongPass";

            WindowsElement loginTextBox = DesktopSession.FindElementByAccessibilityId("loginTextBox");
            loginTextBox.SendKeys(testLogin);
            WindowsElement passwordTextBox = DesktopSession.FindElementByAccessibilityId("passwordTextBox");
            passwordTextBox.SendKeys(testWrongPassword);

            WindowsElement loginButton = DesktopSession.FindElementByAccessibilityId("loginButton");
            loginButton.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            var allWindowHandles = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles[0]);

            WindowsElement ErrorBar = DesktopSession.FindElementByAccessibilityId("65535");
            string ActErrorText = ErrorBar.GetAttribute("Name");
            Console.WriteLine(ActErrorText);

            WindowsElement AcceptClick = DesktopSession.FindElementByAccessibilityId("2");
            AcceptClick.Click();

            Assert.AreEqual("User is undefined!", ActErrorText);

            loginTextBox.Clear();
            loginTextBox.SendKeys(testLogin);
            passwordTextBox.Clear();
            passwordTextBox.SendKeys(testPassword);
            loginButton.Click();

            Assert.Pass();
            DesktopSession.Close();
            DesktopSession.Quit();
        }

        // Сценарий 3: Пользователь пытается войти, забыв указать одно из полей, получает ошибку о том, 
        // что не запролнил все поля, закрывает её, заново вводит данные и успешно входит в систему

        [Test]
        public void Test3_no_data()
        {
            String testLogin = "test1";
            String testPassword = "12345";

            WindowsElement loginTextBox = DesktopSession.FindElementByAccessibilityId("loginTextBox");
            WindowsElement passwordTextBox = DesktopSession.FindElementByAccessibilityId("passwordTextBox");
            WindowsElement loginButton = DesktopSession.FindElementByAccessibilityId("loginButton");

            loginTextBox.SendKeys(testLogin);
            loginButton.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            var allWindowHandles = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles[0]);

            WindowsElement ErrorBar = DesktopSession.FindElementByAccessibilityId("65535");
            string ActErrorText = ErrorBar.GetAttribute("Name");

            WindowsElement AcceptClick = DesktopSession.FindElementByAccessibilityId("2");
            AcceptClick.Click();

            loginTextBox.Clear();
            loginTextBox.SendKeys(testLogin);
            passwordTextBox.Clear();
            passwordTextBox.SendKeys(testPassword);
            loginButton.Click();

            
            Assert.AreEqual("Enter login and password", ActErrorText);
            DesktopSession.Close();
            DesktopSession.Quit();
        }


        //Сценарий 4: Администратор должен зайти в приложение, перейти во вкладку профессий,
        // добавить профессию, изменить её зарплату

        [Test]
        public void Test4_add_change_delete_post()
        {
            String testLogin = "hr";
            String testPassword = "12345";


            WindowsElement loginTextBox = DesktopSession.FindElementByAccessibilityId("loginTextBox");
            WindowsElement passwordTextBox = DesktopSession.FindElementByAccessibilityId("passwordTextBox");
            WindowsElement loginButton = DesktopSession.FindElementByAccessibilityId("loginButton");

            loginTextBox.SendKeys(testLogin);
            passwordTextBox.SendKeys(testPassword);
            loginButton.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            var allWindowHandles = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles[0]);

            WindowsElement postsButton = DesktopSession.FindElementByAccessibilityId("postsButton");
            postsButton.Click();

            WindowsElement postNameTextBox = DesktopSession.FindElementByAccessibilityId("postNameTextBox");
            WindowsElement salaryTextBox = DesktopSession.FindElementByAccessibilityId("salaryTextBox");
            WindowsElement addPostButton = DesktopSession.FindElementByAccessibilityId("addPostButton");

            WindowsElement newSalaryTextBox = DesktopSession.FindElementByAccessibilityId("newSalaryTextBox");
            WindowsElement changePostButton = DesktopSession.FindElementByAccessibilityId("changePostButton");
            WindowsElement deletePostButton = DesktopSession.FindElementByAccessibilityId("deletePostButton");

            postNameTextBox.SendKeys("newpost");
            salaryTextBox.SendKeys("1234");
            addPostButton.Click();

            WindowsElement SortButton = DesktopSession.FindElementByName("Post ID");
            SortButton.Click();
            SortButton.Click();

            WindowsElement postNameCell = DesktopSession.FindElementByName("Post Строка 0");
            postNameCell.Click();
            string postName = postNameCell.GetAttribute("Value.Value");

            WindowsElement postToChange = DesktopSession.FindElementByName("Post ID Строка 0");
            postToChange.Click();

            newSalaryTextBox.SendKeys("1010");
            changePostButton.Click();

            SortButton.Click();
            SortButton.Click();

            DesktopSession.Close();
            DesktopSession.Quit();
            Assert.AreEqual(postName, "newpost");
        }
        
        

        //Сценарий 5: Админ заходит в систему, и нанимает раннее зарегестрированного тестового пользователя,
        // на желаемую им должность. Затем переходит на страницу работников, и удостоверяется, что пользователь
        // получил должность и числится в системе как работяга.

        [Test]
        public void Test5_hire_user()
        {
            String testLogin = "hr";
            String testPassword = "12345";

            WindowsElement loginTextBox = DesktopSession.FindElementByAccessibilityId("loginTextBox");
            WindowsElement passwordTextBox = DesktopSession.FindElementByAccessibilityId("passwordTextBox");
            WindowsElement loginButton = DesktopSession.FindElementByAccessibilityId("loginButton");

            loginTextBox.SendKeys(testLogin);
            passwordTextBox.SendKeys(testPassword);
            loginButton.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            var allWindowHandles = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles[0]);

            WindowsElement newbiesButton = DesktopSession.FindElementByAccessibilityId("newbiesButton");
            WindowsElement workersButton = DesktopSession.FindElementByAccessibilityId("workersButton");
            newbiesButton.Click();

            WindowsElement hireButton = DesktopSession.FindElementByAccessibilityId("hireButton");
            WindowsElement SortButton = DesktopSession.FindElementByName("ID");
            SortButton.Click();
            SortButton.Click();

            WindowsElement hireCell = DesktopSession.FindElementByName("ID Строка 0");
            hireCell.Click();
            string hireId = hireCell.GetAttribute("Value.Value");

            hireButton.Click();
            workersButton.Click();

            WindowsElement SortButton2 = DesktopSession.FindElementByName("ID");
            SortButton2.Click();
            SortButton2.Click();

            WindowsElement hiredCell = DesktopSession.FindElementByName("ID Строка 0");
            hiredCell.Click();
            string hiredId = hiredCell.GetAttribute("Value.Value");

            DesktopSession.Close();
            DesktopSession.Quit();
            Assert.AreEqual(hireId, hiredId);
        }
        

        //Сценарий 6: Пользователь заходит и убеждается, что его наняли на работу. Заходит в окно заявок,
        // и оставляет 3 заявки. Подумав что 3 заявки будет много, последнюю из них удаляет. Убеждается в том, 
        // что заявки появились в таблице заявок. 

        [Test]
        public void Test6_make_requests()
        {
            String testLogin = "test1";
            String testPassword = "12345";

            WindowsElement loginTextBox = DesktopSession.FindElementByAccessibilityId("loginTextBox");
            WindowsElement passwordTextBox = DesktopSession.FindElementByAccessibilityId("passwordTextBox");
            WindowsElement loginButton = DesktopSession.FindElementByAccessibilityId("loginButton");

            loginTextBox.SendKeys(testLogin);
            passwordTextBox.SendKeys(testPassword);
            loginButton.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            var allWindowHandles = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles[0]);

            WindowsElement requestButton = DesktopSession.FindElementByAccessibilityId("requestButton");
            requestButton.Click();

            WindowsElement requestBox = DesktopSession.FindElementByAccessibilityId("requestBox");
            WindowsElement makeRequestButton = DesktopSession.FindElementByAccessibilityId("requestButton");
            WindowsElement deleteButton = DesktopSession.FindElementByAccessibilityId("deleteButton");

            requestBox.Click();
            requestBox.FindElementByName("Dismissal").Click();

            makeRequestButton.Click();
            makeRequestButton.Click();
            makeRequestButton.Click();
            deleteButton.Click();

            WindowsElement SortButton = DesktopSession.FindElementByName("ID");
            SortButton.Click();
            SortButton.Click();

            WindowsElement requestCell0 = DesktopSession.FindElementByName("Name Строка 0");
            requestCell0.Click();
            string request0 = requestCell0.GetAttribute("Value.Value");

            WindowsElement requestCell1 = DesktopSession.FindElementByName("Name Строка 1");
            requestCell1.Click();
            string request1 = requestCell0.GetAttribute("Value.Value");

            Assert.AreEqual(request0, "Dismissal");
            Assert.AreEqual(request1, "Dismissal");
            DesktopSession.Close();
            DesktopSession.Quit();
        }

        //Сценарий 7: Админ заходит в систему, переходит на страницу заявок. Проверяет существующие заявки.
        // Сортирует заявки по убыванию ID, выбирает первую заявку и отклоняет её. Затем выбирает вторую
        // заявку и одобряет её. 

        [Test]
        public void Test7_accept_and_decline_requests()
        {
            String testLogin = "hr";
            String testPassword = "12345";

            WindowsElement loginTextBox = DesktopSession.FindElementByAccessibilityId("loginTextBox");
            WindowsElement passwordTextBox = DesktopSession.FindElementByAccessibilityId("passwordTextBox");
            WindowsElement loginButton = DesktopSession.FindElementByAccessibilityId("loginButton");

            loginTextBox.SendKeys(testLogin);
            passwordTextBox.SendKeys(testPassword);
            loginButton.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            var allWindowHandles = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles[0]);

            WindowsElement requstsButton = DesktopSession.FindElementByAccessibilityId("requstsButton");
            requstsButton.Click();

            WindowsElement approveButton = DesktopSession.FindElementByAccessibilityId("approveButton");
            WindowsElement disapproveButton = DesktopSession.FindElementByAccessibilityId("disapproveButton");

            WindowsElement sortButton = DesktopSession.FindElementByName("Request ID");
            sortButton.Click();
            sortButton.Click();

            WindowsElement requestName0 = DesktopSession.FindElementByName("Name Строка 0");
            requestName0.Click();
            string request0 = requestName0.GetAttribute("Value.Value");
            WindowsElement requestCell0 = DesktopSession.FindElementByName("Request ID Строка 0");
            requestCell0.Click();
            disapproveButton.Click();

            WindowsElement requestName1 = DesktopSession.FindElementByName("Name Строка 0");
            requestName1.Click();
            string request1 = requestName1.GetAttribute("Value.Value");
            WindowsElement requestCell1 = DesktopSession.FindElementByName("Request ID Строка 0");
            requestCell1.Click();
            approveButton.Click();

            Assert.AreEqual(request0, "Test Name");
            Assert.AreEqual(request1, "Test Name");
            DesktopSession.Close();
            DesktopSession.Quit();
        }
        
        //Сценарий 8: Админ переходит на страницу вакансий, добавляет 2 новых вакансий по созданной должности.
        //Проверяет наличие вакансии в таблице, затем добавляет еще 3 вакансии, проверяет, 
        //что в таблице кол-во вакансий увеличилось на 3. Затем удаляет вакансии, переходит
        //обратно на страницу должностей и удаляет должность. 

        [Test]
        public void Test8_add_delete_vacancy()
        {
            String testLogin = "hr";
            String testPassword = "12345";

            WindowsElement loginTextBox = DesktopSession.FindElementByAccessibilityId("loginTextBox");
            WindowsElement passwordTextBox = DesktopSession.FindElementByAccessibilityId("passwordTextBox");
            WindowsElement loginButton = DesktopSession.FindElementByAccessibilityId("loginButton");

            loginTextBox.SendKeys(testLogin);
            passwordTextBox.SendKeys(testPassword);
            loginButton.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            var allWindowHandles = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles[0]);

            WindowsElement postsButton = DesktopSession.FindElementByAccessibilityId("postsButton");
            WindowsElement vacanciesButton = DesktopSession.FindElementByAccessibilityId("vacanciesButton");

            vacanciesButton.Click();
            WindowsElement addVacancyButton = DesktopSession.FindElementByAccessibilityId("addVacancyButton");
            WindowsElement deleteVacancyButton = DesktopSession.FindElementByAccessibilityId("deleteVacancyButton");
            WindowsElement postComboBox = DesktopSession.FindElementByAccessibilityId("postComboBox");
            WindowsElement amountTextBox = DesktopSession.FindElementByAccessibilityId("amountTextBox");

            postComboBox.Click();
            postComboBox.FindElementByName("newpost").Click();
            amountTextBox.SendKeys("2");
            addVacancyButton.Click();

            WindowsElement sortButton = DesktopSession.FindElementByName("Post ID");
            sortButton.Click();
            sortButton.Click();

            WindowsElement count0 = DesktopSession.FindElementByName("Amount Строка 0");
            count0.Click();
            string numCount0 = count0.GetAttribute("Value.Value");

            Thread.Sleep(TimeSpan.FromSeconds(1));

            amountTextBox.Clear();
            amountTextBox.SendKeys("3");
            addVacancyButton.Click();

            WindowsElement count1 = DesktopSession.FindElementByName("Amount Строка 0");
            count1.Click();
            string numCount1 = count1.GetAttribute("Value.Value");

            WindowsElement vacancyToDelete = DesktopSession.FindElementByName("Post ID Строка 0");
            vacancyToDelete.Click();
            deleteVacancyButton.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));
            Assert.AreEqual(numCount0, "2");
            Assert.AreEqual(numCount1, "5");

            DesktopSession.Close();
            DesktopSession.Quit();
        }
        

        //Сценарий 9: Пользователь заходит, переходит в окно запросов, 
        // проверяет что в первом запросе ему отказали, а второй запрос ему одобрили.
        // После проверки удаляет оба запроса и выходит из системы.

        [Test]
        public void Test9_check_and_delete_requests()
        {
            String testLogin = "test1";
            String testPassword = "12345";

            WindowsElement loginTextBox = DesktopSession.FindElementByAccessibilityId("loginTextBox");
            WindowsElement passwordTextBox = DesktopSession.FindElementByAccessibilityId("passwordTextBox");
            WindowsElement loginButton = DesktopSession.FindElementByAccessibilityId("loginButton");

            loginTextBox.SendKeys(testLogin);
            passwordTextBox.SendKeys(testPassword);
            loginButton.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            var allWindowHandles = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles[0]);

            WindowsElement requestButton = DesktopSession.FindElementByAccessibilityId("requestButton");
            requestButton.Click();
            WindowsElement deleteButton = DesktopSession.FindElementByAccessibilityId("deleteButton");

            WindowsElement approval0 = DesktopSession.FindElementByName("Approval Строка 0");
            approval0.Click();
            string approvalValue0 = approval0.GetAttribute("Value.Value");

            WindowsElement approval1 = DesktopSession.FindElementByName("Approval Строка 1");
            approval1.Click();
            string approvalValue1 = approval1.GetAttribute("Value.Value");

            WindowsElement requestToDelete0 = DesktopSession.FindElementByName("ID Строка 0");
            requestToDelete0.Click();
            deleteButton.Click();

            WindowsElement requestToDelete1 = DesktopSession.FindElementByName("ID Строка 0");
            requestToDelete1.Click();
            deleteButton.Click();

            Assert.AreEqual(approvalValue0, "Approved");
            Assert.AreEqual(approvalValue1, "Disapproved");
            DesktopSession.Close();
            DesktopSession.Quit();
        }

        //Сценарий 10: Админ заходит в систему, переходит на страницу должностей, удаляет должность newpost.
        //Затем переходит в окно работников изменяет должность выбранного пользователя. Убеждается что должность
        // изменилась. После чего увольняет тестового пользователя и выходит из системы.

        [Test]
        public void Test9_delete_post_fire_user()
        {
            String testLogin = "hr";
            String testPassword = "12345";

            WindowsElement loginTextBox = DesktopSession.FindElementByAccessibilityId("loginTextBox");
            WindowsElement passwordTextBox = DesktopSession.FindElementByAccessibilityId("passwordTextBox");
            WindowsElement loginButton = DesktopSession.FindElementByAccessibilityId("loginButton");

            loginTextBox.SendKeys(testLogin);
            passwordTextBox.SendKeys(testPassword);
            loginButton.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            var allWindowHandles = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles[0]);

            WindowsElement postsButton = DesktopSession.FindElementByAccessibilityId("postsButton");
            WindowsElement workersButton = DesktopSession.FindElementByAccessibilityId("workersButton");
            postsButton.Click();

            WindowsElement deletePostButton = DesktopSession.FindElementByAccessibilityId("deletePostButton");
            WindowsElement SortButton = DesktopSession.FindElementByName("Post ID");
            SortButton.Click();
            SortButton.Click();

            WindowsElement postToDelete = DesktopSession.FindElementByName("Post ID Строка 0");
            postToDelete.Click();
            deletePostButton.Click();

            workersButton.Click();
            WindowsElement fireButton = DesktopSession.FindElementByAccessibilityId("fireButton");
            WindowsElement workerChangeComboBox = DesktopSession.FindElementByAccessibilityId("workerChangeComboBox");
            WindowsElement workerChangeButton = DesktopSession.FindElementByAccessibilityId("workerChangeButton");

            WindowsElement SortButton2 = DesktopSession.FindElementByName("ID");
            SortButton2.Click();
            SortButton2.Click();

            WindowsElement userToChange = DesktopSession.FindElementByName("ID Строка 0");
            userToChange.Click();
            workerChangeComboBox.Click();
            workerChangeComboBox.FindElementByName("Секретарь").Click();
            workerChangeButton.Click();

            SortButton2.Click();
            SortButton2.Click();
            WindowsElement changedPost = DesktopSession.FindElementByName("Post Строка 0");
            string changedPostValue = changedPost.GetAttribute("Value.Value");
            WindowsElement userToFire = DesktopSession.FindElementByName("ID Строка 0");
            userToFire.Click();
            fireButton.Click();

            Assert.AreEqual(changedPostValue, "Секретарь");
            DesktopSession.Close();
            DesktopSession.Quit();
        }
    }
}