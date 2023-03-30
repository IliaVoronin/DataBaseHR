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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            new RegisterForm().ShowDialog();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var login = loginTextBox.Text;
            var password = passwordTextBox.Text;
            var encryptedPassword = EncryptionDecryptionUsingSymmetricKey.AesOperation.EncryptString("b14ca5898a4e4133bbce2ea2315a1916", password);


            if (login != "" && password != "")
            {
                var dataBaseTable = DBUtils.Select(String.Format("SELECT * FROM userTable WHERE userLogin='{0}' AND userPassword='{1}'", login, encryptedPassword));
                if (dataBaseTable.Count > 0)
                {
                    int userGroupId = (int)dataBaseTable[0][1];
                    Form formToShow;

                    switch (userGroupId)
                    {
                        case 2: 
                            formToShow = new WorkerForm((int) dataBaseTable[0][0], (int)dataBaseTable[0][4]); 
                            break;
                        case 3: 
                            formToShow = new HRForm(); 
                            break;
                        default:
                            formToShow = new NewbieForm((int) dataBaseTable[0][0]);
                            break;
                    }

                    formToShow.Show();
                    formToShow.FormClosed += new FormClosedEventHandler((o, a) =>
                    {
                        this.Close();
                    });

                    this.Hide();

                }
                else 
                {
                    MessageBox.Show("User is undefined!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
            MessageBox.Show("Enter login and password");
        }
    }
}
