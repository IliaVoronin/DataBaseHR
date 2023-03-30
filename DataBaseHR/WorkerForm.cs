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
    public partial class WorkerForm : Form
    {

        public int currentUserId;
        public int currentPostId;
        public List<object[]> infoTable;
        public List<object[]> postTable = DBUtils.Select(String.Format("SELECT postId, postName FROM postTable"));

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
            DBUtils.ExecuteCommand(String.Format("UPDATE infoTable SET infoName = '{0}', infoSurname = '{1}', " +
                "infoSex = '{2}', infoMail = '{3}', infoDate = '{4}', infoCountry = '{5}' WHERE infoUserId = {6}", nameBox.Text, surnameBox.Text,
                sexBox.Text, emailBox.Text, dateBox.Text, countryBox.Text, currentUserId));
        }

        private void updateInfo()
        {
            infoTable = DBUtils.Select(String.Format("SELECT * FROM infoTable WHERE infoUserId = {0}", currentUserId));
            nameLabel.Text = (string)infoTable[0][2];
            surnameLabel.Text = (string)infoTable[0][3];
            sexLabel.Text = (string)infoTable[0][4];
            emailLabel.Text = (string)infoTable[0][5];
            dateLabel.Text = (string)infoTable[0][6];
            countryLabel.Text = (string)infoTable[0][7];
            postLabel.Text = (string)postTable[currentPostId - 1][1];
        }

        private void requestButton_Click(object sender, EventArgs e)
        {
            new MakeRequestForm(currentUserId).ShowDialog();
        }
    }
}
