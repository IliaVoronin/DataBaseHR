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
    public partial class HRForm : Form
    {
        public List<object[]> workersTable;
        public List<object[]> newbieTable;
        public List<object[]> requestTable;
        public List<object[]> vacanciesTable;
        public List<object[]> postTable;
        OleDbConnection connection = DBUtils.CreateConnection("MSOLEDBSQL.1", "DESKTOP-OK3BIT4", "SSPI", "HRD");
        public HRForm()
        {
            InitializeComponent();
        }

        private void HRForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet3.postTable". При необходимости она может быть перемещена или удалена.
            this.postTableTableAdapter.Fill(this.dataSet3.postTable);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet3.postTable". При необходимости она может быть перемещена или удалена.
            this.postTableTableAdapter.Fill(this.dataSet3.postTable);
            foreach (Control c in this.Controls)
            {
                if (c is Panel) c.Visible = false;
            }
            updateWorkerInfo();
            panel1.Show();
        }

        //WORKER PANEL

        public void updateWorkerInfo()
        {
            workersTable = DBUtils.Select("EXEC updateWorkerInfo");
            workerGridView.Rows.Clear();
            workerGridView.Refresh();

            DBUtils.Fill(workerGridView, workersTable);
        }


        private void workersButton_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is Panel) c.Visible = false;
            }
            updateWorkerInfo();
            panel1.Show();
        }

        private void workerChangeButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.workerGridView.SelectedRows)
            {
                DBUtils.ExecuteCommand(String.Format("UPDATE userTable SET userPost = {0} " +
                    "WHERE userId = {1}", workerChangeComboBox.SelectedValue, (int)item.Cells[0].Value), connection);
            }
            updateWorkerInfo();
        }

        private void fireButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.workerGridView.SelectedRows)
            {
                workerGridView.Rows.RemoveAt(item.Index);
                deleteRow((int)item.Cells[0].Value);
            }
        }
        public string deleteRow(int id)
        {
            DBUtils.ExecuteCommand(String.Format("DELETE FROM userTable WHERE userId = {0}", id), connection);
            return "Row deleted";
        }

        //NEWBIE PANEL

        private void newbiesButton_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is Panel) c.Visible = false;
            }
            updateNewbieInfo();
            panel2.Show();
        }

        public void updateNewbieInfo()
        {
            newbieTable = DBUtils.Select("EXEC updateNewbieInfo");
            newbiesGridView.Rows.Clear();
            newbiesGridView.Refresh();

            DBUtils.Fill(newbiesGridView, newbieTable);
        }

        private void hireButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.newbiesGridView.SelectedRows)
            {
                newbiesGridView.Rows.RemoveAt(item.Index);
                DBUtils.ExecuteCommand(String.Format("UPDATE userTable SET userGroup = 2, userPost = " +
                    "(SELECT infoPostId FROM infoTable WHERE infoUserId = {0}) WHERE userId = {0}", (int)item.Cells[0].Value), connection);
            }
        }

        private void declineButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.newbiesGridView.SelectedRows)
            {
                newbiesGridView.Rows.RemoveAt(item.Index);
                deleteRow((int)item.Cells[0].Value);
            }
        }

        //REQUEST PANEL

        public void updateRequestInfo()
        {
            requestTable = DBUtils.Select("EXEC updateRequestInfo");
            requestsGridView.Rows.Clear();
            requestsGridView.Refresh();

            DBUtils.Fill(requestsGridView, requestTable);
        }

        private void requstsButton_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is Panel) c.Visible = false;
            }
            updateRequestInfo();
            panel3.Show();
        }

        private void approveButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.requestsGridView.SelectedRows)
            {
                requestsGridView.Rows.RemoveAt(item.Index);
                approveButton_logic((int)item.Cells[0].Value);
            }
        }

        public string approveButton_logic(int requestId)
        {
            DBUtils.ExecuteCommand(String.Format("UPDATE requestTable " +
                    "SET requestIsApproved = 'Approved' " +
                    "WHERE requestId = {0}", requestId), connection);
            return "Request approved";
        }

        private void disapproveButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.requestsGridView.SelectedRows)
            {
                requestsGridView.Rows.RemoveAt(item.Index);
                DBUtils.ExecuteCommand(String.Format("UPDATE requestTable " +
                    "SET requestIsApproved = 'Disapproved' " +
                    "WHERE requestId = {0}", (int)item.Cells[0].Value), connection);
            }
        }

        //VACANCIES PANEL

        private void vacanciesButton_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is Panel) c.Visible = false;
            }
            updateVacanciesInfo();
            panel5.Hide();
            panel4.Show();
        }

        public void updateVacanciesInfo()
        {
            vacanciesTable = DBUtils.Select("EXEC updateVacanciesInfo");
            vacanciesGridView.Rows.Clear();
            vacanciesGridView.Refresh();

            DBUtils.Fill(vacanciesGridView, vacanciesTable);
        }


        private void addVacancyButton_Click(object sender, EventArgs e)
        {
            DBUtils.ExecuteCommand(String.Format("insert into vacancyTable values ({0}, {1})", postComboBox.Text, amountTextBox.Text), connection);
            addPostButton_logic(postComboBox.Text, amountTextBox.Text);
            updateVacanciesInfo();
        }

        public string addVacancyButton_logic(string vacancyId, string salary)
        {
            try
            {
                DBUtils.ExecuteCommand(String.Format("insert into vacancyTable values ({0}, {1})", vacancyId, salary), connection);
                return "Vacancy added";
            }
            catch (System.Data.OleDb.OleDbException)
            {
                //MessageBox.Show("Недопустивые данные");
                return "Invalid data";
            }
        }

        private void deleteVacancyButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.vacanciesGridView.SelectedRows)
            {
                vacanciesGridView.Rows.RemoveAt(item.Index);
                deleteVacancyRow((int)item.Cells[0].Value);
            }
        }

        public void deleteVacancyRow(int id)
        {
            DBUtils.ExecuteCommand(String.Format("DELETE FROM vacancyTable WHERE vacancyPostId = {0}", id), connection);
        }

        //POST PANEL

        private void postsButton_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is Panel) c.Visible = false;
            }
            updatePostInfo();
            panel5.Show();
        }

        public void updatePostInfo()
        {
            postTable = DBUtils.Select("SELECT * FROM postTable");
            postGridView.Rows.Clear();
            postGridView.Refresh();

            DBUtils.Fill(postGridView, postTable);
        }

        private void addPostButton_Click(object sender, EventArgs e)
        {
            addPostButton_logic(postNameTextBox.Text, salaryTextBox.Text);
            updatePostInfo();
        }

        public string addPostButton_logic(string postName, string postSalary) 
        {
            try 
            {
                DBUtils.ExecuteCommand(String.Format("INSERT INTO postTable(postName, postSalary) values ('{0}',{1})"
                , postName, postSalary), connection);
                return "Post added";
            } catch(System.Data.OleDb.OleDbException)
            {
                //MessageBox.Show("Недопустивые данные");
                return "Invalid data";
            }
        }

        private void changePostButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.postGridView.SelectedRows)
            {
                changePostButton_logic(newSalaryTextBox.Text, (int)item.Cells[0].Value);
            }
            updatePostInfo();
        }

        public string changePostButton_logic(string newSalary, int postId)
        {
            try
            {
                DBUtils.ExecuteCommand(String.Format("UPDATE postTable " +
                    "SET postSalary = {0} " +
                    "WHERE postId = {1}", newSalary, postId), connection);
                return "Post changed";
            } catch (System.Data.OleDb.OleDbException)
            {
                //MessageBox.Show("Недопустивые данные");
                return "Invalid data";
            }
        }

        private void deletePostButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.postGridView.SelectedRows)
            {
                deletePostButton_logic((int)item.Cells[0].Value);
            }
            updatePostInfo();
        }

        public string deletePostButton_logic(int postId)
        {
            DBUtils.ExecuteCommand(String.Format("DELETE FROM postTable WHERE postId = {0}", (postId)), connection);
            return "Post deleted";
        }
    }
}
