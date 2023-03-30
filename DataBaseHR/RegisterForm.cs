using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseHR
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            List<object[]> checkTable;
            var login = loginRegisterTextBox.Text;
            var password = passwordRegisterTextBox.Text;
            string encryptedPassword;

            if (login != "" && password != "")
            {
                if (password.Length < 4)
                {
                    MessageBox.Show("Password must contain atleast 4 symbols");
                    return;
                }

                checkTable = DBUtils.Select(String.Format("SELECT userLogin FROM userTable WHERE userLogin='{0}'", login));

                if (checkTable.Any())
                {
                    MessageBox.Show("Username taken");
                    return;

                } else {

                    encryptedPassword = EncryptionDecryptionUsingSymmetricKey.AesOperation.EncryptString("b14ca5898a4e4133bbce2ea2315a1916", password);
                    Console.WriteLine(encryptedPassword);
                DBUtils.ExecuteCommand(String.Format("insert into userTable(userGroup, userLogin, userPassword ,userPost) values (1, '{0}','{1}', 1)", login, encryptedPassword));
                this.Close();
                MessageBox.Show("Regestration succesful");
                return;
                }
            }

            MessageBox.Show("Fill in all forms");

        }
    }
}
