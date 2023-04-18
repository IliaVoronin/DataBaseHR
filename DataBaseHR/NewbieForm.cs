using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseHR
{
    public partial class NewbieForm : Form
    {

        public int currentUserId;
        public int desiredPostId;
        public List<object[]> infoTable;
        public List<object[]> postTable = DBUtils.Select(String.Format("SELECT postId, postName FROM postTable"));
        OleDbConnection connection = DBUtils.CreateConnection("MSOLEDBSQL.1", "DESKTOP-OK3BIT4", "SSPI", "HRD");

        public NewbieForm(int id)
        {
            InitializeComponent();
            currentUserId = id;
        }

        private void NewbieForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet2.postTable". При необходимости она может быть перемещена или удалена.
            this.postTableTableAdapter1.Fill(this.dataSet2.postTable);
            updateInfo();
            panel1.Show();
            panel2.Hide();
        }

        private void changeInfoButton_Click(object sender, EventArgs e)
        {
            panel2.Show();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            updateInfo();
            panel2.Hide();
            panel1.Show();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
           saveButton_logic(nameBox.Text, surnameBox.Text,
                sexBox.Text, emailBox.Text, dateBox.Text, countryBox.Text, postBox.SelectedIndex, currentUserId);
        }

        public string saveButton_logic(string name, string surname, string sex, string mail, string date, string country, int postid, int currentuser)
        {
            if (name != "" && surname != "" && sex != "" && mail != "" && date != "" && country != "")
            {
                DBUtils.ExecuteCommand(String.Format("UPDATE infoTable SET infoName = '{0}', infoSurname = '{1}', " +
                    "infoSex = '{2}', infoMail = '{3}', infoDate = '{4}', infoCountry = '{5}', infoPostId = {6} WHERE infoUserId = {7}", name, surname,
                    sex, mail, date, country, postid + 1, currentuser), connection);
                return "Updated";
            }
            else {
                //MessageBox.Show("Fill info");
                return "Fill info";
            }
        }
         
        private void updateInfo()
        {
            nameLabel.Text = getName(currentUserId);
            surnameLabel.Text = getSurname(currentUserId);
            sexLabel.Text = getSex(currentUserId);
            emailLabel.Text = getMail(currentUserId);
            dateLabel.Text = getDate(currentUserId);
            countryLabel.Text = getCountry(currentUserId);
            desiredPostId = getPost(currentUserId);
            postLabel.Text = (string)postTable[desiredPostId - 1][1];
        }

        public string getName(int userid)
        {
            var name = DBUtils.Select(String.Format("SELECT infoName FROM infoTable WHERE infoUserId = {0}", userid));
            return (string)name[0][0];
        }

        public string getSurname(int userid)
        {
            var surname = DBUtils.Select(String.Format("SELECT infoSurname FROM infoTable WHERE infoUserId = {0}", userid));
            return (string)surname[0][0];
        }
        public string getSex(int userid)
        {
            var sex = DBUtils.Select(String.Format("SELECT infoSex FROM infoTable WHERE infoUserId = {0}", userid));
            return (string)sex[0][0];
        }
        public string getMail(int userid)
        {
            var mail = DBUtils.Select(String.Format("SELECT infoMail FROM infoTable WHERE infoUserId = {0}", userid));
            return (string)mail[0][0];
        }
        public string getDate(int userid)
        {
            var date = DBUtils.Select(String.Format("SELECT infoDate FROM infoTable WHERE infoUserId = {0}", userid));
            return (string)date[0][0];
        }
        public string getCountry(int userid)
        {
            var country = DBUtils.Select(String.Format("SELECT infoCountry FROM infoTable WHERE infoUserId = {0}", userid));
            return (string)country[0][0];
        }
        public int getPost(int userid)
        {
            var post = DBUtils.Select(String.Format("SELECT infoPostId FROM infoTable WHERE infoUserId = {0}", userid));
            return (int)post[0][0];
        }

        private void vacanciesButton_Click(object sender, EventArgs e)
        {
            new CheckVacanciesForm().ShowDialog();
        }
    }
}
