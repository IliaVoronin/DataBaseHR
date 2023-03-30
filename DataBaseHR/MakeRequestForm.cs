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
    public partial class MakeRequestForm : Form
    {
        public int currentUserId;
        public List<object[]> requestTable;

        public MakeRequestForm(int id)
        {
            InitializeComponent();
            currentUserId = id;
        }

        private void requestButton_Click(object sender, EventArgs e)
        {
            DBUtils.ExecuteCommand(String.Format("INSERT INTO requestTable (requestUserId, requestTypeId, requestDate, requestIsApproved) " +
                "values ({0}, '{1}', '{2}', '{3}')", currentUserId, requestBox.SelectedValue, DateTime.Today, "Pending"));
            showData();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.requestGridView.SelectedRows)
            {
                requestGridView.Rows.RemoveAt(item.Index);
                deleteRow((int)item.Cells[0].Value);
            }
        }

        public void deleteRow(int id)
        {
            DBUtils.ExecuteCommand(String.Format("DELETE FROM requestTable WHERE requestId = {0}", id));
        }

        public void showData()
        {
            requestTable = DBUtils.Select(String.Format("SELECT r.requestId, a.requestTypeName, r.requestDate, r.requestIsApproved FROM requestTable AS r " +
                "JOIN requestTypeTable AS a ON (r.requestTypeId=a.requestTypeId) " +
                "WHERE requestUserId = {0}", currentUserId));

            requestGridView.Rows.Clear();
            requestGridView.Refresh();

            DBUtils.Fill(requestGridView, requestTable);
        }

        private void MakeRequestForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet4.requestTypeTable". При необходимости она может быть перемещена или удалена.
            this.requestTypeTableTableAdapter.Fill(this.dataSet4.requestTypeTable);
            showData();
        }
    }
}
