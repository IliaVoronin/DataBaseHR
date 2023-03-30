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
    public partial class NewbieForm : Form
    {

        public int currentUserId;
        public int desiredPostId;
        public List<object[]> infoTable;
        public List<object[]> postTable = DBUtils.Select(String.Format("SELECT postId, postName FROM postTable"));

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
            DBUtils.ExecuteCommand(String.Format("UPDATE infoTable SET infoName = '{0}', infoSurname = '{1}', " +
                "infoSex = '{2}', infoMail = '{3}', infoDate = '{4}', infoCountry = '{5}', infoPostId = {6} WHERE infoUserId = {7}", nameBox.Text, surnameBox.Text,
                sexBox.Text, emailBox.Text, dateBox.Text, countryBox.Text, postBox.SelectedIndex + 1, currentUserId));
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
            desiredPostId = (int)infoTable[0][8];
            postLabel.Text = (string)postTable[desiredPostId - 1][1];
        }

        private void vacanciesButton_Click(object sender, EventArgs e)
        {
            new CheckVacanciesForm().ShowDialog();
        }
    }
}
