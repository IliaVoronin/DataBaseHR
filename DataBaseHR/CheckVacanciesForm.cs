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
    public partial class CheckVacanciesForm : Form
    {
        public List<object[]> vacanciesTable;
        public CheckVacanciesForm()
        {
            InitializeComponent();
        }

        public void showData()
        {
            vacanciesTable = DBUtils.Select("EXEC showData");
            vacanciesGridView.Rows.Clear();
            vacanciesGridView.Refresh();

            DBUtils.Fill(vacanciesGridView, vacanciesTable);
        }

        private void CheckVacanciesForm_Load(object sender, EventArgs e)
        {
            showData();
        }
    }
}
