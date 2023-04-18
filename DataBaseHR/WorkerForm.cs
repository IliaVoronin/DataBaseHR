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
    public partial class WorkerForm : Form
    {

        public int currentUserId;
        public int currentPostId;
        public List<object[]> infoTable;
        public List<object[]> postTable = DBUtils.Select(String.Format("SELECT postId, postName FROM postTable"));
        OleDbConnection connection = DBUtils.CreateConnection("MSOLEDBSQL.1", "DESKTOP-OK3BIT4", "SSPI", "HRD");

        public WorkerForm(int id, int postId)
        {
            InitializeComponent();
            currentUserId = id;
            currentPostId = postId;
        }

        private void WorkerForm_Load(object sender, EventArgs e)
        {
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
            saveButton_logic(nameBox.Text, surnameBox.Text, sexBox.Text, emailBox.Text, 
                dateBox.Text, countryBox.Text, currentUserId);
        }

        public string saveButton_logic(string name, string surname, string sex, string mail, string date, string country, int currentuser)
        {
            if (name != "" && surname != "" && sex != "" && mail != "" && date != "" && country != "")
            {
                DBUtils.ExecuteCommand(String.Format("UPDATE infoTable SET infoName = '{0}', infoSurname = '{1}', " +
                    "infoSex = '{2}', infoMail = '{3}', infoDate = '{4}', infoCountry = '{5}' WHERE infoUserId = {6}", name, surname,
                    sex, mail, date, country, currentuser), connection);
                return "Updated";
            }
            else
            {
                //MessageBox.Show("Fill info");
                return "Fill info";
            }
        }

        private void updateInfo()
        {
            infoTable = DBUtils.Select(String.Format("SELECT * FROM infoTable WHERE infoUserId = {0}", currentUserId));
            nameLabel.Text = getName(currentUserId);
            surnameLabel.Text = getSurname(currentUserId);
            sexLabel.Text = getSex(currentUserId);
            emailLabel.Text = getMail(currentUserId);
            dateLabel.Text = getDate(currentUserId);
            countryLabel.Text = getCountry(currentUserId);
            postLabel.Text = (string)postTable[currentPostId - 1][1];
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

        private void requestButton_Click(object sender, EventArgs e)
        {
            new MakeRequestForm(currentUserId).ShowDialog();
        }
    }
}
