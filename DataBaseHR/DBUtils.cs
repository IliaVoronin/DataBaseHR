using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseHR
{


    class DBUtils
    {

        public static void ExecuteCommand(string cmdString)
        {
            using (var connection = CreateConnection())
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = cmdString;
                cmd.Connection = connection;
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static OleDbConnection CreateConnection()
        {
            return new OleDbConnection("Provider=MSOLEDBSQL.1;Data Source=DESKTOP-OK3BIT4;Integrated Security=SSPI;Initial Catalog=HRDatabase");
        }

        public static List<object[]> Select(string cmdString)
        {
            List<Object[]> o = new List<Object[]>();
            using (var connection = CreateConnection())
            {
                OleDbCommand select = new OleDbCommand();
                select.Connection = connection;
                select.CommandText = cmdString;
                connection.Open();

                OleDbDataReader reader = select.ExecuteReader();
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    for (var i = 0; i < reader.FieldCount; i++) data[i] = reader[i];
                    o.Add(data);
                }
            }
            return o;

        }

        public static void Fill(DataGridView gridView, List<Object[]> list)
        {
            int i = 0;
            foreach (var item in list)
            {
                gridView.Rows.Add();
                for (int j = 0; j < gridView.ColumnCount; j++)
                {
                    gridView.Rows[i].Cells[j].Value = item[j];
                }
                i++;
            }
        }

    }
}
