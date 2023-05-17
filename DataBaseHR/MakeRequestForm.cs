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
            requestButton_logic(currentUserId, Convert.ToInt32(requestBox.SelectedValue), DateTime.Today);
        }

        public string requestButton_logic(int currentUserId, int requestType, DateTime dateTime)
        {
            try { 
            DBUtils.ExecuteCommand(String.Format("INSERT INTO requestTable (requestUserId, requestTypeId, requestDate, requestIsApproved) " +
                "values ({0}, '{1}', '{2}', '{3}')", currentUserId, requestType, dateTime, "Pending"));
            showData();
            return "Request added";
            } catch (Exception e)
            {
                return "Invalid data";
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell item in this.requestGridView.SelectedCells)
            {
                //requestGridView.Rows.RemoveAt(item.Index);
                deleteRow((int)item.Value);
            }
            showData();
        }

        public string deleteRow(int id)
        {
            try
            {
                DBUtils.ExecuteCommand(String.Format("DELETE FROM requestTable WHERE requestId = {0}", id));
                return "Request deleted";
            }
            catch (Exception e)
            {
                return "Invalid data";
            }
        }

        public string showData()
        {
            requestTable = getData(currentUserId);
            requestGridView.Rows.Clear();
            requestGridView.Refresh();
            DBUtils.Fill(requestGridView, requestTable);
            return "Data accesed";
        }

        public List<object[]> getData(int currentUserId)
        {
            List<object[]> table = DBUtils.Select(String.Format("SELECT r.requestId, a.requestTypeName, r.requestDate, r.requestIsApproved FROM requestTable AS r " +
                "JOIN requestTypeTable AS a ON (r.requestTypeId=a.requestTypeId) " +
                "WHERE requestUserId = {0}", currentUserId));
            return table;
        }

        private void MakeRequestForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "requestTypeDataSet.requestTypeTable". При необходимости она может быть перемещена или удалена.
            this.requestTypeTableTableAdapter1.Fill(this.requestTypeDataSet.requestTypeTable);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet4.requestTypeTable". При необходимости она может быть перемещена или удалена.
            this.requestTypeTableTableAdapter.Fill(this.dataSet4.requestTypeTable);
            showData();
        }
    }
}
